using System;

namespace Blazor.Fluxor.Routing
{
	/// <summary>
	/// State used by <see cref="RoutingMiddleware"/> and <see cref="RoutingFeature"/>.
	/// </summary>
	public class RoutingState
	{
		/// <summary>
		/// The browser address
		/// </summary>
		public string Uri { get; set; } // TODO: Make setter private https://github.com/aspnet/Blazor/issues/705

		/// <summary>
		/// Required by DevTools to recreate historic state
		/// </summary>
		[Obsolete("For deserialization purposes only. Use the constructor with parameters")]
		public RoutingState() { } 

		/// <summary>
		/// Creates a new instance of the state
		/// </summary>
		/// <param name="uri">The new value of the URI state</param>
		public RoutingState(string uri)
		{
			Uri = uri;
		}
	}
}
