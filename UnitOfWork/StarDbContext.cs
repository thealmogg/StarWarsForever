using Microsoft.EntityFrameworkCore;
using StarWarsForever.Core.Model;

namespace StarWarsForever.UnitOfWork
{
    public class StarDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Image> Images { get; set; }
        public StarDbContext(DbContextOptions<StarDbContext> options) : base(options){}

    }
}