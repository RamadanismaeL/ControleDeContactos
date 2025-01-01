using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Enums;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.Models
{
    public class UserModel
    {
        private int _id;
        private string? _firstName, _email, _userName, _password;
        private UserProfileEnum _profile;
        private UserStatusEnum _status;
        private DateTime _dateRegister;

        public int GetId() => _id;
            public string? GetFirstName() => this._firstName;
                public string? GetEmail() => this._email;
                    public string? GetUserName() => this._userName;
                        public string? GetPassword() => this._password;
                            public UserProfileEnum GetProfile() => this._profile;
                                public UserStatusEnum GetStatus() => this._status;
                                    public DateTime GetDateRegister() => this._dateRegister;
                                    //public void SetDateRegister(DateTime dateRegister) => this._dateRegister = dateRegister;
                                public void setStatus(UserStatusEnum status) => this._status = status;
                            public void setProfile(UserProfileEnum profile) => this._profile = profile;
                        public void setPassword(string password) => this._password = password;
                    public void setUserName(string userName) => this._userName = userName;
                public void setEmail(string email) => this._email = email;
            public void setFirstName(string firstName) => this._firstName = firstName;
        public void SetId(int id) => _id = id;
    }
}