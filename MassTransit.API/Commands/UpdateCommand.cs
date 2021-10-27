using System.ComponentModel.DataAnnotations;

namespace MassTransit.API.Commands
{
    public class UpdateCommand
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
