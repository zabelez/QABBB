using System;
using QABBB.API.Models.Company.Employee;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class CompanyEmployeeAssembler
    {

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
            //companyEmployeeDTO.RemovedAt = companyEmployee.RemovedAt;
            //companyEmployeeDTO.RemovedBy = companyEmployee.RemovedBy;
            //companyEmployeeDTO.RemovedByName = companyEmployee.RemovedByNavigation?.IdPersonNavigation.PersonName;
            
            return companyEmployeeDTO;
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
    }
}

