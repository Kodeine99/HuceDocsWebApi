using System.Threading.Tasks;
using HuceDocs.Notification.Email.Models;

namespace HuceDocs.Notification.Email
{
    public interface IEmailProvider
    {
        Task<bool> ExecuteAsync(EmailProviderParameter parameter);
        Task<EmailTemplates> GetTemplatesAsync();
        Task<EmailTemplate> GetTemplateByNameAsync(string templateName);
        Task<EmailTemplate> GetTemplateByIdAsync(string id);
    }
}