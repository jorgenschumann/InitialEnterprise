using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Blazor.Fluxor.Routing
{
	internal class GoEffect : Effect<Go>
	{
		private readonly NavigationManager NavigationManager;

		public GoEffect(NavigationManager navigationManager)
		{
			NavigationManager = navigationManager;
		}

		protected override Task HandleAsync(Go action, IDispatcher dispatcher)
		{
			Uri fullUri = NavigationManager.ToAbsoluteUri(action.NewUri);
			if (fullUri.ToString() != NavigationManager.Uri)
			{
				// Only navigate if we are not already at the URI specified
				NavigationManager.NavigateTo(action.NewUri);
			}
			return Task.CompletedTask;
		}
	}
}
