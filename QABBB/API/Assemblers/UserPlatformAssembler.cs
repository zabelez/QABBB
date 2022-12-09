using System;
using QABBB.API.Models.User.Platform;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class UserPlatformAssembler
    {

        public UserPlatformDTO toUserPlatformDTO(UserPlatform userPlatform) {

            UserPlatformDTO userPlatformDTO = new UserPlatformDTO();
            userPlatformDTO.IdUserPlatform = userPlatform.IdUserPlatform;
            userPlatformDTO.Name = userPlatform.IdPlatformNavigation.Name;
            userPlatformDTO.CreatedAt = userPlatform.CreatedAt;
            userPlatformDTO.CreatedByName = userPlatform.CreatedByNavigation.IdPersonNavigation.PersonName;
            userPlatformDTO.CreatedById = userPlatform.CreatedBy;

            return userPlatformDTO;
        }

        public List<UserPlatformDTO> toUserPlatformDTO(IEnumerable<UserPlatform> userPlatforms) {

            List<UserPlatformDTO> userPlatformDTOs = new List<UserPlatformDTO>();

            foreach (UserPlatform userPlatform in userPlatforms) {
                userPlatformDTOs.Add(toUserPlatformDTO(userPlatform));
            }

            return userPlatformDTOs;
        }
    }
}

