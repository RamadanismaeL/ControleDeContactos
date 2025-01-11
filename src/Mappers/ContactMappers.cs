
using controleDeContactos.src.Dtos;
using controleDeContactos.src.Models;


/**
**@author Ramadan Ismael
*/
namespace controleDeContactos.src.Mappers
{
    public static class ContactMappers
    {
        public static ContactDtos ToContactDto(this ContactModel contactModel)
        {
            return new ContactDtos
            {
                Name = contactModel.Name,
                LastName = contactModel.LastName,
                Email = contactModel.Email,
                PhoneNumber = contactModel.PhoneNumber
            };
        }
    }
}