using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public class TypeMessage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
