using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }                
        public List<Message> Messages { get; set; } = new List<Message>();

    }
}
