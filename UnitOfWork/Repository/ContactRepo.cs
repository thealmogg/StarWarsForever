using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsForever.Core;
using StarWarsForever.Core.Model;

namespace StarWarsForever.UnitOfWork.Repository
{
    public class ContactRepo : IContactRepo
    {
        protected StarDbContext StarDbContext { get; }

        public ContactRepo(StarDbContext starDbContext)
        {
            this.StarDbContext = starDbContext;

        }
        public async Task<Contact> GetContact(int id, bool includeRelated = true)
        {
            if(includeRelated) {
            return await StarDbContext.Contacts
            .Include(c => c.Weapons)
            .Include(c => c.ProfileImage)
            .SingleOrDefaultAsync(c => c.Id == id);
            }

            return await StarDbContext.Contacts.FindAsync(id);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await StarDbContext.Contacts
            .Include(c => c.Weapons)
            .Include(c => c.ProfileImage)
            .ToListAsync();
        }
        public void Add(Contact contact)
        {
            StarDbContext.Contacts.Add(contact);
        }


        public void Remove(Contact contact)
        {
            StarDbContext.Contacts.Remove(contact);
        }

    }
}