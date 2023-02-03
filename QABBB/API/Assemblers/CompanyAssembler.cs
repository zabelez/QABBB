using System;
using QABBB.API.Models.Company;
using QABBB.API.Models.Company.Employee;
using QABBB.API.Models.User;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class CompanyAssembler
    {

        public CompanyDTO toCompanyDTO(Company company) {

            CompanyDTO companyDTO = new CompanyDTO();
            companyDTO.IdCompany = company.IdCompany;
            companyDTO.Name = company.Name;
            companyDTO.Logo = company.Logo;

            foreach (var employee in company.CompanyEmployees)
            {
                CompanyEmployeeForCompanyDTO employeeDTO = new CompanyEmployeeForCompanyDTO();
                employeeDTO.IdCompanyEmployee = employee.IdCompanyEmployee;
                employeeDTO.IdPerson = employee.IdCompanyEmployee;
                employeeDTO.PersonName = employee.IdPersonNavigation.IdPersonNavigation.PersonName;
                employeeDTO.Position = employee.IdPositionNavigation.Name;
                employeeDTO.CreatedAt = employee.CreatedAt;

                companyDTO.Employees.Add(employeeDTO);
            }
            
            return companyDTO;
        }

        public Company toCompany(Company company, CompanyEditInputDTO companyEditInputDTO){
            company.Name = companyEditInputDTO.Name;
            company.Logo = companyEditInputDTO.Logo;
            return company;
        }

        public List<CompanyDTO> toCompanyDTO(IEnumerable<Company> companies) {

            List<CompanyDTO> companyDTO = new List<CompanyDTO>();

            foreach (Company company in companies) {
                companyDTO.Add(toCompanyDTO(company));
            }

            return companyDTO;
        }

        public Company toCompany(CompanyInputDTO companyInputDTO) {

            Company company = new Company();
            company.Name = companyInputDTO.Name;
            company.Logo = companyInputDTO.Logo;
            company.CompanyParent = companyInputDTO.CompanyParent;

            return company;
        }
    }
}

