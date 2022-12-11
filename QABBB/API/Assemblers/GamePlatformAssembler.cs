using System;
using QABBB.API.Models.Game.Platform;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class GamePlatformAssembler
    {

        public GamePlatformDTO toGamePlatformDTO(GamePlatform gamePlatform) {

            GamePlatformDTO gamePlatformDTO = new GamePlatformDTO();
            gamePlatformDTO.IdGamePlatform = gamePlatform.IdGamePlatform;
            gamePlatformDTO.Name = gamePlatform.IdPlatformNavigation.Name;
            
            return gamePlatformDTO;
        }

        public List<GamePlatformDTO> toGamePlatformDTO(IEnumerable<GamePlatform>? gamePlatforms) {

            if(gamePlatforms == null)
                return new List<GamePlatformDTO>();

            List<GamePlatformDTO> gamePlatformDTOs = new List<GamePlatformDTO>();

            foreach (GamePlatform gamePlatform in gamePlatforms) {
                gamePlatformDTOs.Add(toGamePlatformDTO(gamePlatform));
            }

            return gamePlatformDTOs;
        }

        internal GamePlatform toGamePlatform(GamePlatformInputDTO gamePlatformInputDTO)
        {
            GamePlatform gamePlatform = new GamePlatform();
            gamePlatform.IdGame = gamePlatformInputDTO.IdGame;
            gamePlatform.IdPlatform = gamePlatformInputDTO.IdPlatform;

            return gamePlatform;
        }
    }
}

