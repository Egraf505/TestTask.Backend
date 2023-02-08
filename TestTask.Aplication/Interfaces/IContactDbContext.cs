using Microsoft.EntityFrameworkCore;
using TestTask.Domain;

namespace TestTask.Aplication.Interfaces
{
    public interface IContactDbContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<TypeMessage> TypeMessages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
