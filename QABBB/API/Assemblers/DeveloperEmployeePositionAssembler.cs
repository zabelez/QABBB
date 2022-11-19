using System;
using QABBB.Models;
using QABBB.API.Models.Company.Employee;
using QABBB.API.Models.Developer;
using QABBB.API.Models.Developer.Employee;

namespace QABBB.API.Assemblers
{
    public class DeveloperEmployeePositionAssembler
    {

        public DeveloperEmployeePositionDTO toDeveloperEmployeePositionDTO(DeveloperEmployeePosition position) {

            DeveloperEmployeePositionDTO positionDTO = new DeveloperEmployeePositionDTO();
            positionDTO.IdPosition = position.IdDeveloperEmployeePosition;
            positionDTO.Name = position.Name;
            
            return positionDTO;
        }

        public DeveloperEmployeePosition toDeveloperEmployeePosition(DeveloperEmployeePosition developerEmployeePosition, DeveloperEmployeePositionEditInputDTO developerEmployeePositionEditInputDTO){
            developerEmployeePosition.Name = developerEmployeePositionEditInputDTO.Name;
            developerEmployeePosition.IdDeveloperEmployeePosition = developerEmployeePositionEditInputDTO.IdPosition;
            return developerEmployeePosition;
        }

        public List<DeveloperEmployeePositionDTO> toDeveloperEmployeePositionDTO(IEnumerable<DeveloperEmployeePosition> companies) {

            List<DeveloperEmployeePositionDTO> developerEmployeePositionDTO = new List<DeveloperEmployeePositionDTO>();

            foreach (DeveloperEmployeePosition developerEmployeePosition in companies) {
                developerEmployeePositionDTO.Add(toDeveloperEmployeePositionDTO(developerEmployeePosition));
            }

            return developerEmployeePositionDTO;
        }

        public DeveloperEmployeePosition toDeveloperEmployeePosition(DeveloperEmployeePositionInputDTO developerEmployeePositionInputDTO) {

            DeveloperEmployeePosition developerEmployeePosition = new DeveloperEmployeePosition();
            developerEmployeePosition.Name = developerEmployeePositionInputDTO.Name;

            return developerEmployeePosition;
        }
    }
}

