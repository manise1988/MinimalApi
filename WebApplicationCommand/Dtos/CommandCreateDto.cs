using System.ComponentModel.DataAnnotations;

namespace WebApplicationCommand.Dtos
{
    public class CommandCreateDto
    {

        [Required]
        [MaxLength(5)]
        public string HowTo { get; set; }

        [Required]
        public string Platform { get; set; }

        [Required]
        public string CommandLine { get; set; }
    }
}
