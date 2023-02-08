using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain;

namespace TestTask.Persistence.EntityTypeConfigurations
{
    public class TypeMessageConfiguration : IEntityTypeConfiguration<TypeMessage>
    {
        public void Configure(EntityTypeBuilder<TypeMessage> builder)
        {
            builder.HasKey(messageType => messageType.Id);
            builder.Property(messageType => messageType.Title).HasMaxLength(250);            
        }
    }
}
