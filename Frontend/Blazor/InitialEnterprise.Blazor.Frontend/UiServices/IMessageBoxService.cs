using System.Threading.Tasks;

namespace InitialEnterprise.Frontend.UiServices
{  
    public interface IMessageBoxService
    {       
        Task ShowMessage(string message, string title);

        Task<bool> ShowMessage(string message, string title, string primaryButton);
    }
}
