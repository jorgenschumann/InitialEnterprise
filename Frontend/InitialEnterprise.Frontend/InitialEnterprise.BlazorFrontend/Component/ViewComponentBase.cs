using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using InitialEnterprise.BlazorFrontend.UiServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace InitialEnterprise.BlazorFrontend.Component
{
    public class ViewComponentBase : ComponentBase
    {
        [Inject]
        public IMessageBoxService MessageBox { get; set; }
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

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

        protected string Error(string propertyName)
        {
            if (ValidationResult != null)
            {
                if (ValidationResult.Errors.FirstOrDefault(e => e.PropertyName == propertyName) != null)
                {
                    return "error";
                }
            }
            return string.Empty;
        }

        public void DisplayErrors(EditContext context)
        {
            var messageStore = new ValidationMessageStore(context);
            foreach (var err in this.ValidationResult.Errors)
            {
                messageStore.Add(context.Field(err.PropertyName), err.ErrorMessage);
            }
            context.NotifyValidationStateChanged();
        }
    }
}
