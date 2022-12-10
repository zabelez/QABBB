using QABBB.API.Models.Game;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class GameAssembler
    {
        GamePlatformAssembler gamePlatformAssembler = new GamePlatformAssembler();

        public GameDTO toGameDTO(Game game) {

            GameDTO gameDTO = new GameDTO();
            gameDTO.IdGame = game.IdGame;
            gameDTO.IdDeveloper = game.IdDeveloper;
            gameDTO.IdPublisher = game.IdPublisher;
            gameDTO.Name = game.Name;
            gameDTO.Gamelogo = game.Gamelogo;
            gameDTO.Developer = game.IdDeveloperNavigation.Name;
            gameDTO.Publisher = game.IdPublisherNavigation.Name;
            
            return gameDTO;
        }

        public GameAndPlatformsDTO toGameAndPlatformsDTO(Game game) {

            GameAndPlatformsDTO newGame = new GameAndPlatformsDTO();
            newGame.IdGame = game.IdGame;
            newGame.IdDeveloper = game.IdDeveloper;
            newGame.IdPublisher = game.IdPublisher;
            newGame.Name = game.Name;
            newGame.Gamelogo = game.Gamelogo;
            newGame.Developer = game.IdDeveloperNavigation.Name;
            newGame.Publisher = game.IdPublisherNavigation.Name;

            newGame.Platforms = gamePlatformAssembler.toGamePlatformDTO(game.GamePlatforms);

            return newGame;
        }

        public Game toGame(Game game, GameEditInputDTO gameEditInputDTO){
            game.IdDeveloper = gameEditInputDTO.IdDeveloper;
            game.IdPublisher = gameEditInputDTO.IdPublisher;
            game.Name = gameEditInputDTO.Name;
            game.Gamelogo = gameEditInputDTO.Gamelogo;
            return game;
        }

        public List<GameDTO> toGameDTO(IEnumerable<Game> companies) {

            List<GameDTO> gameDTO = new List<GameDTO>();

            foreach (Game game in companies) {
                gameDTO.Add(toGameDTO(game));
            }

            return gameDTO;
        }

        public Game toGame(GameInputDTO gameInputDTO) {

            Game game = new Game();
            game.IdDeveloper = gameInputDTO.IdDeveloper;
            game.IdPublisher = gameInputDTO.IdPublisher;
            game.Name = gameInputDTO.Name;
            game.Gamelogo = gameInputDTO.Gamelogo;
            
            return game;
        }
    }
}

