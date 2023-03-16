using System;
using QABBB.API.Models.Company.Employee;
using QABBB.API.Models.Project;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class CompanyEmployeeAssembler
    {
        public ProjectAssembler projectAssembler = new ProjectAssembler();

        public CompanyEmployeeDTO toCompanyEmployeeDTO(CompanyEmployee companyEmployee) {

            CompanyEmployeeDTO companyEmployeeDTO = new CompanyEmployeeDTO();
            companyEmployeeDTO.IdCompanyEmployee = companyEmployee.IdCompanyEmployee;
            companyEmployeeDTO.IdCompany = companyEmployee.IdCompany;
            companyEmployeeDTO.CompanyName = companyEmployee.IdCompanyNavigation.Name;
            companyEmployeeDTO.IdPerson = companyEmployee.IdPerson;
            companyEmployeeDTO.PersonName = companyEmployee.IdPersonNavigation.IdPersonNavigation.PersonName;
            companyEmployeeDTO.Position = companyEmployee.IdPositionNavigation.Name;
            companyEmployeeDTO.CreatedAt = companyEmployee.CreatedAt;
            companyEmployeeDTO.CreatedBy = companyEmployee.CreatedBy;
            companyEmployeeDTO.CreatedByName = companyEmployee.CreatedByNavigation.IdPersonNavigation.PersonName;
            
            return companyEmployeeDTO;
        }

        public CompanyEmployeeForCompanyDTO toCompanyEmployeeForCompanyDTO(CompanyEmployee companyEmployee) {
            CompanyEmployeeForCompanyDTO employeeDTO = new CompanyEmployeeForCompanyDTO();
            employeeDTO.IdCompanyEmployee = companyEmployee.IdCompanyEmployee;
            employeeDTO.IdPerson = companyEmployee.IdPersonNavigation.IdPerson;
            employeeDTO.PersonName = companyEmployee.IdPersonNavigation.IdPersonNavigation.PersonName;
            employeeDTO.IdPosition = companyEmployee.IdPosition;
            employeeDTO.Position = companyEmployee.IdPositionNavigation.Name;
            employeeDTO.CreatedAt = companyEmployee.CreatedAt;

            return employeeDTO;
        }
        public List<CompanyEmployeeForUserDTO> toCompanyEmployeeForUserDTO(IEnumerable<CompanyEmployee> companyEmployees) {
            List<CompanyEmployeeForUserDTO> companyEmployeeForUserDTOs = new List<CompanyEmployeeForUserDTO>();
            foreach (var companyEmployee in companyEmployees)
            {
                companyEmployeeForUserDTOs.Add(toCompanyEmployeeForUserDTO(companyEmployee));
            }
            return companyEmployeeForUserDTOs;
        }

        public CompanyEmployeeForUserDTO toCompanyEmployeeForUserDTO(CompanyEmployee companyEmployee) {
            CompanyEmployeeForUserDTO employeeDTO = new CompanyEmployeeForUserDTO();
            employeeDTO.IdCompanyEmployee = companyEmployee.IdCompanyEmployee;
            employeeDTO.IdCompany = companyEmployee.IdCompany;
            employeeDTO.CompanyName = companyEmployee.IdCompanyNavigation.Name;
            employeeDTO.Position = companyEmployee.IdPositionNavigation.Name;
            employeeDTO.CreatedAt = companyEmployee.CreatedAt;

            HashSet<ProjectForUserDTO> projects = new HashSet<ProjectForUserDTO>();
            foreach (var project in companyEmployee.IdCompanyNavigation.ProjectDevelopers)
            {
                projects.Add(projectAssembler.toProjectForUserDTO(project.IdProjectNavigation));
            }
            foreach (var project in companyEmployee.IdCompanyNavigation.ProjectPublishers)
            
            {
                projects.Add(projectAssembler.toProjectForUserDTO(project.IdProjectNavigation));
            }

            employeeDTO.projects = projects.ToList();

            return employeeDTO;
        }

        public List<CompanyEmployeeDTO> toCompanyEmployeeDTO(IEnumerable<CompanyEmployee> companyEmployees) {

            List<CompanyEmployeeDTO> companyEmployeeDTOs = new List<CompanyEmployeeDTO>();

            foreach (CompanyEmployee companyEmployee in companyEmployees) {
                companyEmployeeDTOs.Add(toCompanyEmployeeDTO(companyEmployee));
            }

            return companyEmployeeDTOs;
        }

        public CompanyEmployee toCompanyEmployee(CompanyEmployeeInputDTO companyEmployeeInputDTO) {

            CompanyEmployee companyEmployee = new CompanyEmployee();
            companyEmployee.IdCompany = companyEmployeeInputDTO.IdCompany;
            companyEmployee.IdPerson = companyEmployeeInputDTO.IdPerson;
            companyEmployee.IdPosition = companyEmployeeInputDTO.IdCompanyEmployeePosition;

            return companyEmployee;
        }

        public CompanyEmployee toCompanyEmployee(Company company, CompanyEmployeeInputForPostCompany companyEmployeeInputDTO, int idPerson) {

            CompanyEmployee companyEmployee = new CompanyEmployee();
            companyEmployee.IdCompanyNavigation = company;
            companyEmployee.IdPerson = companyEmployeeInputDTO.IdPerson;
            companyEmployee.IdPosition = companyEmployeeInputDTO.IdPosition;
            companyEmployee.CreatedBy = idPerson;
            companyEmployee.CreatedAt = DateTime.Now;

            return companyEmployee;
        }
        public CompanyEmployee toCompanyEmployee(Company company, CompanyEmployeeInputForPutCompany companyEmployeeInput, int idPerson) {

            CompanyEmployee companyEmployee = new CompanyEmployee();
            companyEmployee.IdCompanyNavigation = company;
            companyEmployee.IdPerson = companyEmployeeInput.IdPerson;
            companyEmployee.IdPosition = companyEmployeeInput.IdPosition;
            companyEmployee.CreatedBy = idPerson;
            companyEmployee.CreatedAt = DateTime.Now;

            return companyEmployee;
        }
    }
}

