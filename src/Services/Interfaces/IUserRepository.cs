using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using controleDeContactos.Models;

namespace controleDeContactos.src.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> Create(UserModel userModel);
        Task<List<UserModel>> Read();
        Task<UserModel> Update(UserModel userModel, int id);
        Task<UserModel> Delete(int id);
        Task<UserModel> FindByID(int id);
        UserModel FindByUsername(string userName);
    }
}