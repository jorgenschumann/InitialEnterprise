using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Blazor.Fluxor.Components
{
	/// <summary>
	/// A component that auto-subscribes to state changes on all <see cref="IState"/> properties
	/// and ensures <see cref="Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged"/> is called
	/// </summary>
	public class FluxorComponent : ComponentBase
	{
		/// <summary>
		/// Subscribes to state properties
		/// </summary>
		protected override void OnInitialized()
		{
			base.OnInitialized();
			// Find all state properties
			const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			IEnumerable<PropertyInfo> stateProperties = GetType().GetProperties(bindingFlags)
				.Where(t => typeof(IState).IsAssignableFrom(t.PropertyType));
			// Subscribe to each state so that StateHasChanged is executed when the state changes
			foreach (PropertyInfo propertyInfo in stateProperties)
			{
				IState state = (IState)propertyInfo.GetValue(this);
				state.Subscribe(this);
			}
		}
	}
}
