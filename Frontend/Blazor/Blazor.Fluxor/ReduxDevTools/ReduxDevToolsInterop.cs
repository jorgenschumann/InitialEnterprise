using Blazor.Fluxor.ReduxDevTools.CallbackObjects;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Schema;
using Json = System.Text.Json.JsonSerializer;

namespace Blazor.Fluxor.ReduxDevTools
{
	/// <summary>
	/// Interop for dev tools
	/// </summary>
	public class ReduxDevToolsInterop
	{

		internal const string DevToolsCallbackId = RootId + "DevToolsCallback";
		internal static bool DevToolsBrowserPluginDetected { get; private set; }
		internal static event EventHandler<JumpToStateCallback> JumpToState;
		internal static event EventHandler AfterJumpToState;
		internal static event EventHandler Commit;

		private const string RootId = "Blazor.Fluxor.ReduxDevTools.ReduxDevToolsInterop.";
		private const string FluxorDevToolsId = "__FluxorDevTools__";
		private const string FromJsDevToolsDetectedActionTypeName = "detected";
		private const string ToJsDispatchMethodName = "dispatch";
		private const string ToJsInitMethodName = "init";
		private readonly IJSRuntime JSRuntime;

		/// <summary>
		/// Creates an instance of the dev tools interop
		/// </summary>
		/// <param name="jsRuntime"></param>
		public ReduxDevToolsInterop(IJSRuntime jsRuntime)
		{
			JSRuntime = jsRuntime;
		}

		internal void Init(IDictionary<string, object> state)
		{
			InvokeFluxorDevToolsMethod<object>(ToJsInitMethodName, state);
		}

		internal void Dispatch(object action, IDictionary<string, object> state)
		{
			InvokeFluxorDevToolsMethod<object>(ToJsDispatchMethodName, new ActionInfo(action), state);
		}

		/// <summary>
		/// Called back from ReduxDevTools
		/// </summary>
		/// <param name="messageAsJson"></param>
		[JSInvokable(DevToolsCallbackId)]
		//TODO: Make private https://github.com/aspnet/Blazor/issues/1218
		public static void DevToolsCallback(string messageAsJson)
		{
			if (string.IsNullOrWhiteSpace(messageAsJson))
				return;

			var message = Json.Deserialize<BaseCallbackObject>(messageAsJson);
			switch (message?.payload?.type)
			{
				case FromJsDevToolsDetectedActionTypeName:
					DevToolsBrowserPluginDetected = true;
					break;

				case "COMMIT":
					Commit?.Invoke(null, EventArgs.Empty);
					break;

				case "JUMP_TO_STATE":
				case "JUMP_TO_ACTION":
					OnJumpToState(Json.Deserialize<JumpToStateCallback>(messageAsJson));
					break;
			}
		}

		private ValueTask<TResult> InvokeFluxorDevToolsMethod<TResult>(string identifier, params object[] args)
		{
			if (!DevToolsBrowserPluginDetected)
				return new ValueTask<TResult>(default(TResult));

			string fullIdentifier = $"{FluxorDevToolsId}.{identifier}";
			return JSRuntime.InvokeAsync<TResult>(fullIdentifier, args);
		}

		private static void OnJumpToState(JumpToStateCallback jumpToStateCallback)
		{
			JumpToState?.Invoke(null, jumpToStateCallback);
			AfterJumpToState?.Invoke(null, EventArgs.Empty);
		}

		internal static string GetClientScripts()
		{
			string assemblyName = typeof(ReduxDevToolsInterop).Assembly.GetName().Name;

			return $@"
window.{FluxorDevToolsId} = new (function() {{
	const reduxDevTools = window.__REDUX_DEVTOOLS_EXTENSION__;
	if (reduxDevTools !== undefined && reduxDevTools !== null) {{
		const fluxorDevTools = reduxDevTools.connect({{ name: 'Blazor-Fluxor' }});
		if (fluxorDevTools !== undefined && fluxorDevTools !== null) {{
			fluxorDevTools.subscribe((message) => {{ 
				const messageAsJson = JSON.stringify(message);
				DotNet.invokeMethodAsync('{assemblyName}', '{DevToolsCallbackId}', messageAsJson); 
			}});
		}}

		this.{ToJsInitMethodName} = function(state) {{
			fluxorDevTools.init(state);
		}};

		this.{ToJsDispatchMethodName} = function(action, state) {{
			fluxorDevTools.send(action, state);
		}};

		// Notify Fluxor of the presence of the browser plugin
		const detectedMessage = {{
			payload: {{
				type: '{ReduxDevToolsInterop.FromJsDevToolsDetectedActionTypeName}'
			}}
		}};
		const detectedMessageAsJson = JSON.stringify(detectedMessage);
		DotNet.invokeMethodAsync('{assemblyName}', '{DevToolsCallbackId}', detectedMessageAsJson);
	}}
}})();
";
		}
	}
}
