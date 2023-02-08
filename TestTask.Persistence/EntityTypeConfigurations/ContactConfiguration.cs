using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain;

namespace TestTask.Persistence.EntityTypeConfigurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(contact => contact.Id);
            builder.Property(contact => contact.Name).IsRequired().HasMaxLength(300);
            builder.Property(contact => contact.Email).IsRequired().HasMaxLength(300);
            builder.Property(contact => contact.Phone).IsRequired().HasMaxLength(11);
            builder.HasOne(contact => contact.TypeMessage).WithMany(typeMessage => typeMessage.Contacts);
        }
    }
}
