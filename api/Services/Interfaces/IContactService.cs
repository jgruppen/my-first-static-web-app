using api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContactsAsync();
    }
}