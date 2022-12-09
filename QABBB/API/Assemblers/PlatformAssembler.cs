using System;
using QABBB.API.Models.Platform;
using QABBB.API.Models.User;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class PlatformAssembler
    {

        public PlatformDTO toPlatformDTO(Platform platform) {

            PlatformDTO platformDTO = new PlatformDTO();
            platformDTO.IdPlatform = platform.IdPlatform;
            platformDTO.Name = platform.Name;
            
            return platformDTO;
        }

        public Platform toPlatform(Platform platform, PlatformEditInputDTO platformEditInputDTO){
            platform.Name = platformEditInputDTO.Name;
            return platform;
        }

        public List<PlatformDTO> toPlatformDTO(IEnumerable<Platform> companies) {

            List<PlatformDTO> platformDTO = new List<PlatformDTO>();

            foreach (Platform platform in companies) {
                platformDTO.Add(toPlatformDTO(platform));
            }

            return platformDTO;
        }

        public Platform toPlatform(PlatformInputDTO platformInputDTO) {

            Platform platform = new Platform();
            platform.Name = platformInputDTO.Name;

            return platform;
        }
    }
}

