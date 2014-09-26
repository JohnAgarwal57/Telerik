namespace Exam.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GameCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string Number { get; set; }
    }
}