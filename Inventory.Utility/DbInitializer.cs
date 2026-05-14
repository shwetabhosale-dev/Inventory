using Inventory.Models;
using Inventory.Repository;
using Inventory.Utility.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace Inventory.Utility
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private SuperAdmin _superAdmin;
        private ApplicationDbContext _context;
        private IRoleInventory _roleInventory;

        public DbInitializer(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<SuperAdmin> superAdmin)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _superAdmin = superAdmin.Value;
        }

        public void CreateRoles()
        {
            throw new NotImplementedException();
        }

        public async Task CreatesuperAdmin()
        {
            AppUser user = new AppUser();
            user.Email = "";
            user.UserName = "";
            user.EmailConfirmed = true;
            var response = await _userManager.CreateAsync(user, _superAdmin.Password);
            if (response.Succeeded)
            {
                UserProfile userProfile = new UserProfile();
                userProfile.FirstName = "Admin";
                userProfile.LastName = "Admin";
                userProfile.Email = user.Email;
                userProfile.AppUserId = user.Id;
                await _context.UserProfiles.AddAsync(userProfile);
                await _context.SaveChangesAsync();
                await _roleInventory.AddRoleAsync(user.Id);
            }
        }  

        public async Task SendEmail(string FromEmail, string Subject, string FromName, string Message, string toEmail, string toName, string smtpUser, string smtpPassward, string smtpHost, string smtpPort, bool smtpSSl)
        {
            var body = Message;
            var messageRequest = new MailMessage();
            messageRequest.To.Add(new MailAddress(toEmail, toName));
            messageRequest.From = new MailAddress(FromEmail, FromName);
            messageRequest.Subject = Subject;
            messageRequest.Body = body;
            messageRequest.IsBodyHtml = true;
            using (var smtp = new SmtpClient(smtpHost, Convert.ToInt32(smtpPort)))
            {
                smtp.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPassward);
                smtp.EnableSsl = smtpSSl;
                await smtp.SendMailAsync(messageRequest);
            }
        }

        public async Task<string> UploadFile(List<IFormFile> files, IWebHostEnvironment env, string Directory)
        {
            var response = string.Empty;
            var uploadPath = Path.Combine(env.WebRootPath, Directory);
            var fileExtension = string.Empty;
            var filePath = string.Empty;
            var fileName = string.Empty;
            foreach(var file in files)
            {
                if (file.Length > 0)
                {
                    fileExtension = Path.GetExtension(file.FileName);
                    fileName = Guid.NewGuid().ToString() + fileExtension;
                    filePath = Path.Combine(uploadPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    response = fileName;
                }
            }
            return response;
        }
    }
}
