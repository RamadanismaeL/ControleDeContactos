using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Enums;
using controleDeContactos.src.config;
using controleDeContactos.src.Models;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public UserProfileEnum Profile { get; set; }
        public UserStatusEnum Status { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateUpdate { get; set; }
        public virtual List<ContactModel>? Contacts { get; set; }

        public bool VerifyPassword(string password) { return BCrypt.Net.BCrypt.Verify(password, Password); }

        public void setPassword()
        {
            if(!string.IsNullOrEmpty(Password)) { Password = Password.CreateEncrypt(); }
            else { throw new ArgumentException("Password can't be null or empty."); }
        }

        public void SetNewPassword(string newPassword) { Password = newPassword.CreateEncrypt(); }

        public string GetNewPassword() {
            string newPassword = Guid.NewGuid().ToString()[..8];
            Password = newPassword.CreateEncrypt();
            return newPassword;
        }
    }
}