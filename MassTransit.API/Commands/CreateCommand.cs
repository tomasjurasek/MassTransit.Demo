using System.ComponentModel.DataAnnotations;

namespace MassTransit.API.Commands
{
    public class CreateCommand
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
