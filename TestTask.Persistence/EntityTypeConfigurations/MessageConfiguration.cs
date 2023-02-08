using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain;

namespace TestTask.Persistence.EntityTypeConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(message => message.Id);
            builder.Property(message => message.Title ).HasMaxLength(500);
            builder.HasOne(message => message.Contact).WithMany(contact => contact.Messages);
        }
    }
}
