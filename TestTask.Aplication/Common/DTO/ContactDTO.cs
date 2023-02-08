using System.ComponentModel.DataAnnotations;

namespace TestTask.Aplication.Common.DTO
{
    public class ContactDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string TypeMessage { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
