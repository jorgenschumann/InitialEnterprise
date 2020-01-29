using System;

namespace Blazor.Fluxor.DependencyInjection
{
	internal class DiscoveredReducerClass
	{
		public readonly Type ImplementingType;
		public readonly Type StateType;

		public DiscoveredReducerClass(Type implementingType, Type stateType)
		{
			ImplementingType = implementingType;
			StateType = stateType;
		}
	}
}
