using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClarkCodingChallenge.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
