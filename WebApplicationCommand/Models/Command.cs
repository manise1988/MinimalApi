using System.ComponentModel.DataAnnotations;

namespace WebApplicationCommand.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(5)]
        public string? HowTo { get; set; }

        [Required]
        public string? Platform { get; set; }

        [Required]
        public string? CommandLine {  get; set; }

    }
}
