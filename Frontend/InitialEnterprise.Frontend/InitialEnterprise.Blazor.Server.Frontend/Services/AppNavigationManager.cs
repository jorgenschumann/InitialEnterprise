using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace InitialEnterprise.Blazor.Frontend.Services
{ 
    public class AppNavigationManager : INavigationManager
    {
        private readonly NavigationManager _navigationManager;

        public AppNavigationManager(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        }
              
        [SuppressMessage("Design", "CA1054:Uri parameters should not be strings", Justification = "Follows NavigationManager from Blazor.")]
        public void NavigateTo(string uri)
        {
            _navigationManager.NavigateTo(uri);
        }
    }
}
