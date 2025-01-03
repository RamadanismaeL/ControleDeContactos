using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Data;
using controleDeContactos.Models;
using controleDeContactos.src.config;
using controleDeContactos.src.Services.Interfaces;

namespace controleDeContactos.src.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly dbTaskContact _dbTaskContact;
        public UserRepository(dbTaskContact dbTaskContact) { this._dbTaskContact = dbTaskContact; }

        public async Task<UserModel> Create(UserModel userModel)
        {
            userModel.setPassword();
            await _dbTaskContact.User.AddAsync(userModel);
            await _dbTaskContact.SaveChangesAsync();
            return userModel;
        }

        public Task<List<UserModel>> Read()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> Update(UserModel userModel, int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel FindByUsername(string userName)
        {
            throw new NotImplementedException();
        }
    }
}