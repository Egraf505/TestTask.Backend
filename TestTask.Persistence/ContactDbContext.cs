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
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<TypeMessage> TypeMessages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new TypeMessageConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
