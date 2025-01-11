
using controleDeContactos.Data;
using controleDeContactos.src.Dtos;
using controleDeContactos.src.Helpers;
using controleDeContactos.src.Mappers;
using controleDeContactos.src.Models;
using controleDeContactos.src.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<object> ReadNLEP()
        {
            //return _dbTaskContact.Contacts.ToList().Select(c => c.ToContactDto());
            var contacts = await _dbTaskContact.Contacts.ToListAsync();
            var contactsDtos = contacts.Select(c => c.ToContactDto());
            return contactsDtos;
        }

        public async Task<object> FilterNL(QueryObject queryObject)
        {
            var contacts = _dbTaskContact.Contacts.Include(c => c.User).AsQueryable();
            if(!string.IsNullOrWhiteSpace(queryObject.Name))
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                contacts = contacts.Where(c => c.Name.Contains(queryObject.Name));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            if(!string.IsNullOrWhiteSpace(queryObject.LastName))
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                contacts = contacts.Where(c => c.LastName.Contains(queryObject.LastName));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }

            var take = await contacts.ToListAsync();
            var contactsDtos = take.Select(c => c.ToContactDto());
            return contactsDtos;
        }
    }
}