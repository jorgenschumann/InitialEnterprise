using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using InitialEnterprise.BlazorFrontend.UiServices;
using Microsoft.AspNetCore.Components;

namespace InitialEnterprise.BlazorFrontend.Component
{  
    public class ViewComponentBase : ComponentBase
    {       
        [Inject]
        public IMessageBoxService MessageBox { get; set; }
                
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error is displayed to user.")]
        protected async Task TryRun(Func<Task> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            try
            {
               await action();
            }
            catch (Exception ex)
            {
                await ShowError(ex);
            }
        }

        protected Task ShowError(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            return MessageBox.ShowMessage(exception.Message, "MessagePanel_Error");
        }
    }
}
