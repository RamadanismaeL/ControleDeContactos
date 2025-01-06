using controleDeContactos.Data;
using controleDeContactos.Models;
using controleDeContactos.src.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly dbTaskContact _dbTaskContact;
        public UserRepository(dbTaskContact dbTaskContact) { this._dbTaskContact = dbTaskContact; }

        public async Task<UserModel> Create(UserModel userModel)
        {
            userModel.setPassword();
            await _dbTaskContact.Users.AddAsync(userModel);
            await _dbTaskContact.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<UserModel>> ReadAll() { return await _dbTaskContact.Users.ToListAsync(); }

        public async Task<UserModel> Update(UserModel userModel, int id)
        {
            UserModel userID = await FindByID(id) ?? throw new KeyNotFoundException($"User with ID : {id}, not founded.");
            userID.FullName = userModel.FullName;
            userID.Email = userModel.Email;
            userID.UserName = userModel.UserName;
            userID.Password = userModel.Password;
            userID.Profile = userModel.Profile;
            userID.Status = userModel.Status;
            userID.DateUpdate = DateTime.Now;
            _dbTaskContact.Users.Update(userID);
            await _dbTaskContact.SaveChangesAsync();
            return userID;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userID = await FindByID(id) ?? throw new KeyNotFoundException($"{id} is not registered.");
            _dbTaskContact.Users.Remove(userID);
            await _dbTaskContact.SaveChangesAsync();
            return true;
        }

        public async Task<UserModel> FindByID(int id) { return await _dbTaskContact.Users.FirstOrDefaultAsync(u => u.Id == id) ?? throw new KeyNotFoundException($"{id} is not registered."); }

        public UserModel FindByUsername(string userName) { return _dbTaskContact.Users.FirstOrDefault(u => (u.UserName ?? "").ToUpper() == userName.ToUpper()) ?? throw new KeyNotFoundException($"{userName} is not registered"); }
    }
}