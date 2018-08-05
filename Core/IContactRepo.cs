using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsForever.Core.Model;

namespace StarWarsForever.Core
{
    public interface IContactRepo
    {
         Task<Contact> GetContact(int id, bool includeRelated = true);
         Task<IEnumerable<Contact>> GetContacts();
         void Add(Contact contact);
         void Remove(Contact contact);
    }
}