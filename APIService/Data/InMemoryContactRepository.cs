using APIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIService
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly List<Contact> _contactList;
        public InMemoryContactRepository()
        {
            _contactList = new List<Contact>
            {
                new Contact
                {
                    Id=101,
                    Name="Amit",
                    Phones= new Phone[]
                    { 
                        new Phone
                        {
                            PhoneType= PhoneType.Home,
                            Number="425-666-7272"
                        },
                        new Phone
                        {
                            PhoneType= PhoneType.Mobile,
                            Number ="889-989-0912"
                        }

                    }
                },
                new Contact
                {
                    Id=201,
                    Name="Linda",
                    Phones= new Phone[]
                    {
                        new Phone
                        {
                            PhoneType= PhoneType.Home,
                            Number="425-666-5932"
                        },
                        new Phone
                        {
                            PhoneType= PhoneType.Mobile,
                            Number ="889-989-1812"
                        }

                    }
                },
                new Contact
                {
                    Id=301,
                    Name="Joey",
                    Phones= new Phone[]
                    {
                        new Phone
                        {
                            PhoneType= PhoneType.Home,
                            Number="525-666-1947"
                        },
                        new Phone
                        {
                            PhoneType= PhoneType.Mobile,
                            Number ="889-989-4356"
                        }

                    }
                },
            };
        }



        public Contact GetContact(int id)
        {
            var contact = _contactList.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                return contact;
            }
            else
                return null;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contactList.OrderBy(x => x.Id).ToList();
        }

        public Contact Add(Contact contact)
        {
            contact.Id = _contactList.Max(x => x.Id) + 100;
            contact.DateAdded = DateTime.UtcNow;
            _contactList.Add(contact);
            return contact;
        }

        public Contact Delete(int id)
        {
            var contact = _contactList.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                _contactList.Remove(contact);
            }
            return contact;
        }

        public Contact Update(int id, Contact updatedContact)
        {
            var contact = _contactList.FirstOrDefault(x => x.Id == id);
            contact.Name = updatedContact.Name;
            contact.Phones = updatedContact.Phones;

            return contact;
    }
    }
}
