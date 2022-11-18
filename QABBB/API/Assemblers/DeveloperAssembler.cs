using System;
using QABBB.API.Models.Developer;
using QABBB.API.Models.User;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class DeveloperAssembler
    {

        public DeveloperDTO toDeveloperDTO(Developer developer) {

            DeveloperDTO developerDTO = new DeveloperDTO();
            developerDTO.IdDeveloper = developer.IdDeveloper;
            developerDTO.IdCompany = developer.IdCompany;
            developerDTO.Name = developer.IdCompanyNavigation.Name;
            
            return developerDTO;
        }

        public List<DeveloperDTO> toDeveloperDTO(IEnumerable<Developer> companies) {

            List<DeveloperDTO> developerDTO = new List<DeveloperDTO>();

            foreach (Developer developer in companies) {
                developerDTO.Add(toDeveloperDTO(developer));
            }

            return developerDTO;
        }

        public Developer toDeveloper(DeveloperInputDTO developerInputDTO) {

            Developer developer = new Developer();
            developer.IdCompany = developerInputDTO.IdCompany;

            return developer;
        }
    }
}

