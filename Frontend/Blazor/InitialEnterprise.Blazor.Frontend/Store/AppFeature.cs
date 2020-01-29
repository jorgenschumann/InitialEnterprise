using Blazor.Fluxor;

namespace InitialEnterprise.Frontend.Store
{
	public class AppFeature : Feature<AppState>
	{
		public override string GetName() => "App";
		protected override AppState GetInitialState() => new AppState();
	}
}
