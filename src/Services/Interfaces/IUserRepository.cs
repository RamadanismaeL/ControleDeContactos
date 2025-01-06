using controleDeContactos.Models;
/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> Create(UserModel userModel);
        Task<List<UserModel>> ReadAll();
        Task<UserModel> Update(UserModel userModel, int id);
        Task<bool> Delete(int id);
        Task<UserModel> FindByID(int id);
        UserModel FindByUsername(string userName);
    }
}