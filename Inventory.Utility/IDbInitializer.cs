using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Inventory.Utility
{
    public interface IDbInitializer
    {
        void CreateRoles();
        Task CreatesuperAdmin();
        Task SendEmail(string FromEmail, string Subject, string FromName, String Message, string toEmail, String toName, 
            string smtpUser, string smtpPassward, string smtpHost, string smtpPort, bool smtpSSl);
        Task<string> UploadFile(List<IFormFile> files,
            IWebHostEnvironment env, string Directory);
    }
}
