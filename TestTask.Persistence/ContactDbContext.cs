using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Aplication.Interfaces;
using TestTask.Domain;
using TestTask.Persistence.EntityTypeConfigurations;

namespace TestTask.Persistence
{
    public class ContactDbContext : DbContext, IContactDbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<TypeMessage> TypeMessages { get; set; } = null!;

        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new TypeMessageConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
