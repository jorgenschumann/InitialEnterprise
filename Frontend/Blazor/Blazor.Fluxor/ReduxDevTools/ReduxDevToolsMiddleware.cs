using Blazor.Fluxor.ReduxDevTools.CallbackObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Json = System.Text.Json.JsonSerializer;

namespace Blazor.Fluxor.ReduxDevTools
{
	/// <summary>
	/// Middleware for interacting with the Redux Devtools extension for Chrome
	/// </summary>
	public class ReduxDevToolsMiddleware : Middleware
	{
		private int SequenceNumberOfCurrentState = 0;
		private int SequenceNumberOfLatestState = 0;
		private readonly ReduxDevToolsInterop ReduxDevToolsInterop;
		private readonly JsonSerializerOptions SerializationOptions;

		/// <summary>
		/// Creates a new instance of the middleware
		/// </summary>
		public ReduxDevToolsMiddleware(ReduxDevToolsInterop reduxDevToolsInterop)
		{
			ReduxDevToolsInterop = reduxDevToolsInterop;
			SerializationOptions = new JsonSerializerOptions {
				PropertyNameCaseInsensitive = true,
				WriteIndented = false
			};
			ReduxDevToolsInterop.JumpToState += OnJumpToState;
			ReduxDevToolsInterop.Commit += OnCommit;
		}

		/// <see cref="IMiddleware.Initialize(IStore)"/>
		public override void Initialize(IStore store)
		{
			base.Initialize(store);
			ReduxDevToolsInterop.Init(GetState());
		}

		/// <see cref="IMiddleware.MayDispatchAction(object)"/>
		public override bool MayDispatchAction(object action)
		{
			return SequenceNumberOfCurrentState == SequenceNumberOfLatestState;
		}

		/// <see cref="IMiddleware.AfterDispatch(object)"/>
		public override void AfterDispatch(object action)
		{
			ReduxDevToolsInterop.Dispatch(action, GetState());

			// As actions can only be executed if not in a historical state (yes, "a" historical, pronounce your H!)
			// ensure the latest is incremented, and the current = latest
			SequenceNumberOfLatestState++;
			SequenceNumberOfCurrentState = SequenceNumberOfLatestState;
		}

		private IDictionary<string, object> GetState()
		{
			var state = new Dictionary<string, object>();
			foreach (IFeature feature in Store.Features.Values.OrderBy(x => x.GetName()))
				state[feature.GetName()] = feature.GetState();
			return state;
		}

		private void OnCommit(object sender, EventArgs e)
		{
			ReduxDevToolsInterop.Init(GetState());
			SequenceNumberOfCurrentState = SequenceNumberOfLatestState;
		}

		private void OnJumpToState(object sender, JumpToStateCallback e)
		{
			SequenceNumberOfCurrentState = e.payload.actionId;
			using (Store.BeginInternalMiddlewareChange())
			{
				var newFeatureStates = Json.Deserialize<Dictionary<string, object>>(e.state);
				foreach (KeyValuePair<string, object> newFeatureState in newFeatureStates)
				{
					// Get the feature with the given name
					if (!Store.Features.TryGetValue(newFeatureState.Key, out IFeature feature))
						continue;

					var serializedFeatureStateElement = (JsonElement)newFeatureState.Value;
					object stronglyTypedFeatureState = Json.Deserialize(
						json: serializedFeatureStateElement.ToString(),
						returnType: feature.GetStateType(),
						options: SerializationOptions);

					// Now set the feature's state to the deserialized object
					feature.RestoreState(stronglyTypedFeatureState);
				}
			}
		}

		/// <see cref="IMiddleware.GetClientScripts"/>
		public override string GetClientScripts()
		{
			return ReduxDevToolsInterop.GetClientScripts();
		}
	}
}
