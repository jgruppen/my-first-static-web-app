using api.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services
{
    public class ContactService : IContactService
    {
        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return new List<Contact>
            {
                new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = "Jarno Gruppen"
                },

                new Contact
                {
                    Id = Guid.NewGuid(),
                    Name = "Thomas Gruppen"
                }
            };
        }
    }
}
