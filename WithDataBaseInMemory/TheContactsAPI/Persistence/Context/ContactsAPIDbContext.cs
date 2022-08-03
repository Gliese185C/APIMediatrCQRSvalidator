using Microsoft.EntityFrameworkCore;
using Persistence.Entity;

namespace Persistence.Context
{
    public class ContactsAPIDbContext : DbContext
    {
        public ContactsAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
