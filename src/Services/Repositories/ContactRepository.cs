
using controleDeContactos.Data;
using controleDeContactos.src.Models;
using controleDeContactos.src.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;


/**
** @author Ramadan Ismael
*/
namespace controleDeContactos.src.Services.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly dbTaskContact _dbTaskContact;
        public ContactRepository(dbTaskContact dbTaskContact) { this._dbTaskContact = dbTaskContact; }
        public async Task<ContactModel> Create(ContactModel contactModel)
        {
            await _dbTaskContact.Contacts.AddAsync(contactModel);
            await _dbTaskContact.SaveChangesAsync();
            return contactModel;
        }

        public async Task<List<ContactModel>> ReadAll() { return await _dbTaskContact.Contacts.Include(c => c.User).ToListAsync(); }

        public async Task<ContactModel> Update(ContactModel contactModel, int id)
        {
            ContactModel contactID = await FindByID(id) ?? throw new KeyNotFoundException($"Contact with ID : {id}, not found.");
            contactID.Name = contactModel.Name;
            contactID.LastName = contactModel.LastName;
            contactID.Email = contactModel.Email;
            contactID.PhoneNumber = contactModel.PhoneNumber;
            contactID.UserID = contactModel.UserID;
            _dbTaskContact.Contacts.Update(contactID);
            await _dbTaskContact.SaveChangesAsync();
            return contactID;
        }

        public async Task<bool> Delete(int id)
        {
            ContactModel contactID = await FindByID(id) ?? throw new KeyNotFoundException($"Contact with ID : {id}, not found.");
            _dbTaskContact.Contacts.Remove(contactID);
            await _dbTaskContact.SaveChangesAsync();
            return true;
        }

        public async Task<ContactModel> FindByID(int id) { return await _dbTaskContact.Contacts.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id) ?? throw new KeyNotFoundException($"{id} is not registered."); }

        public async Task<List<ContactModel>> FindByName(string name) { return await _dbTaskContact.Contacts.Where(c => c.Name == name).Include(c => c.User).ToListAsync() ?? throw new InvalidOperationException($"{name} not registered."); }
    }
}