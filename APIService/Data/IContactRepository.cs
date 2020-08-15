using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIService
{
    public interface IContactRepository
    {
        Contact GetContact(int id);
        IEnumerable<Contact> GetContacts();
        Contact Add(Contact contact);
        Contact Update(int id, Contact updatedContact);
        Contact Delete(int id);
    }
}
