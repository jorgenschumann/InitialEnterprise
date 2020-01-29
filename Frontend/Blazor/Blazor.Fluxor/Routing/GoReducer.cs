namespace Blazor.Fluxor.Routing
{
	internal class GoReducer : Reducer<RoutingState, Go>
	{
		public override RoutingState Reduce(RoutingState state, Go action) => new RoutingState(action.NewUri ?? "");
	}
}
