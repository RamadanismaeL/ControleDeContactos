using controleDeContactos.src.Models;

/**
** @auhor Ramadan Ismael
*/
namespace controleDeContactos.src.Services.Interfaces
{
    public interface IContactRepository
    {
        Task<ContactModel> Create(ContactModel contactModel);
        Task<List<ContactModel>> ReadAll();
        Task<ContactModel> Update(ContactModel contactModel, int id);
        Task<bool> Delete(int id);
        Task<ContactModel> FindByID(int id);
        Task<List<ContactModel>> FindByName(string name);
    }
}