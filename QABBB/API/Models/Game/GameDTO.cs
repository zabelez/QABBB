namespace QABBB.API.Models.Game
{
    public class GameDTO
    {
        public int IdGame { get; set; }
        public string Name { get; set; } = null!;
        public string? Gamelogo { get; set; }
        public int IdPublisher { get; set; }
        public string? Publisher { get; set;}
        public int IdDeveloper { get; set; }
        public string? Developer {get; set;}

    }
}