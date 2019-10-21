using System.Threading.Tasks;

namespace InitialEnterprise.BlazorFrontend.UiServices
{  
    public interface IMessageBoxService
    {       
        Task ShowMessage(string message, string title);

        Task<bool> ShowMessage(string message, string title, string primaryButton);
    }
}
