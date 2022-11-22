using System;
using QABBB.API.Models.Developer.Employee;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class DeveloperEmployeeAssembler
    {

        public DeveloperEmployeeDTO toDeveloperEmployeeDTO(DeveloperEmployee developerEmployee) {

            DeveloperEmployeeDTO developerEmployeeDTO = new DeveloperEmployeeDTO();
            developerEmployeeDTO.IdDeveloperEmployee = developerEmployee.IdDeveloperEmployee;
            developerEmployeeDTO.Company = developerEmployee.IdDeveloperNavigation.IdCompanyNavigation.Name;
            developerEmployeeDTO.PersonName = developerEmployee.IdUserNavigation.IdPersonNavigation.PersonName;
            developerEmployeeDTO.Position = developerEmployee.IdPositionNavigation.Name;
            developerEmployeeDTO.Status = developerEmployeeDTO.Status;
            
            return developerEmployeeDTO;
        }

        public DeveloperEmployee toDeveloperEmployee(DeveloperEmployee developerEmployee, DeveloperEmployeeEditInputDTO developerEmployeeEditInputDTO){
            developerEmployee.IdDeveloperEmployee = developerEmployeeEditInputDTO.IdDeveloperEmployee;
            developerEmployee.IdPosition = developerEmployeeEditInputDTO.IdPosition;
            developerEmployee.Status = developerEmployeeEditInputDTO.Status;
            
            return developerEmployee;
        }

        public List<DeveloperEmployeeDTO> toDeveloperEmployeeDTO(IEnumerable<DeveloperEmployee> companies) {

            List<DeveloperEmployeeDTO> developerEmployeeDTO = new List<DeveloperEmployeeDTO>();

            foreach (DeveloperEmployee developerEmployee in companies) {
                developerEmployeeDTO.Add(toDeveloperEmployeeDTO(developerEmployee));
            }

            return developerEmployeeDTO;
        }

        public DeveloperEmployee toDeveloperEmployee(DeveloperEmployeeInputDTO developerEmployeeInputDTO) {

            DeveloperEmployee developerEmployee = new DeveloperEmployee();
            developerEmployee.IdDeveloper = developerEmployeeInputDTO.IdDeveloper;
            developerEmployee.IdUser = developerEmployeeInputDTO.IdUser;
            developerEmployee.IdPosition = developerEmployeeInputDTO.IdPosition;
            developerEmployee.Status = developerEmployeeInputDTO.Status;

            return developerEmployee;
        }
    }
}

