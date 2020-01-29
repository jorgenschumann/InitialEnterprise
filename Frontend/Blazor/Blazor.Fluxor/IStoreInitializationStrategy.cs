using System;

namespace Blazor.Fluxor
{
	/// <summary>
	/// A strategy pattern for initialising a store
	/// </summary>
	public interface IStoreInitializationStrategy
	{
		/// <summary>
		/// Initialises the store
		/// </summary>
		/// <param name="completed">The action to call back once the store is ready to be initialised</param>
		void Initialize(Action completed);
	}
}
