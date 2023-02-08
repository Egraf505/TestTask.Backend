using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(ContactDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
