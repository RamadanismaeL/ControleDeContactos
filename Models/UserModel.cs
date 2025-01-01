using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Enums;

namespace controleDeContactos.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your full name.")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter your username.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please select a profile.")]
        public UserProfileEnum Profile { get; set; }
        [Required(ErrorMessage = "Please select a status.")]
        public UserStatus Status { get; set; }
        public DateTime DateRegister { get; set; }

        [Required(ErrorMessage = "Please enter your id.")]
        private int _id;
        public int GetId() => _id;
        public void SetId(int id) => _id = id;

        /*
        private int _id;

        public int Id
        {
            get => _id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ID must be a positive number.");
                _id = value;
            }
        }
    */
    }
}