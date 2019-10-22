using System;
using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.UiServices
{  
    public class MessageBoxService : IMessageBoxService
    {
        private Func<string, string, string, Task<bool>> _messageHandler;

        public Task ShowMessage(string message, string title)
        {
            return ShowMessage(message, title, null);
        }

        public Task<bool> ShowMessage(string message, string title, string primaryButton)
        {
            var handler = _messageHandler;
            if (handler != null)
            {
                return handler(message, title, primaryButton);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public void SetMessageHandler(Func<string, string, string, Task<bool>> handler)
        {
            _messageHandler = handler;
        }
    }
}
