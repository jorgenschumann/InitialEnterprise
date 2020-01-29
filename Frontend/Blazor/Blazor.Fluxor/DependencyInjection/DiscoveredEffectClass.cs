using System;

namespace Blazor.Fluxor.DependencyInjection
{
	internal class DiscoveredEffectClass
	{
		public readonly Type ImplementingType;

		public DiscoveredEffectClass(Type implementingType)
		{
			ImplementingType = implementingType;
		}
	}
}
