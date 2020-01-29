using System;

namespace InitialEnterprise.Frontend.UiServices
{    
    public class BusyIndicatorService : IBusyIndicatorService
    {
        private Action<bool> _handler;
        private int _counter;

        
        public IDisposable Show()
        {
            if (_counter == 0)
            {
                _handler?.Invoke(true);
            }

            _counter++;
            return new BusyIndicatorOperation(this);
        }
    
        public void SetBusyIndicatorHandler(Action<bool> handler)
        {
            _handler = handler;
        }

        private void Hide()
        {
            _counter--;
            if (_counter == 0)
            {
                _handler?.Invoke(false);
            }
        }

        private sealed class BusyIndicatorOperation : IDisposable
        {
            private readonly BusyIndicatorService _service;
            private bool _disposed;

            public BusyIndicatorOperation(BusyIndicatorService service)
            {
                _service = service;
            }

            public void Dispose()
            {
                if (!_disposed)
                {
                    _service.Hide();
                    _disposed = true;
                }
            }
        }
    }
}
