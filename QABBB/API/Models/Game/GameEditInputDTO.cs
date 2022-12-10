using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Game
{
    public class GameEditInputDTO
    {
        [Required]
        public int IdGame { get; set; }
        [Required]
        public int IdPublisher { get; set; }
        [Required]
        public int IdDeveloper { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Gamelogo { get; set; }

    }
}