namespace Exam.WebAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GameBlueJoinModel
    {
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string Number { get; set; }
    }
}