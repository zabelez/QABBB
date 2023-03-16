using System;
using QABBB.API.Models.Company;
using QABBB.API.Models.Company.Employee;
using QABBB.API.Models.User;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class CompanyAssembler
    {
        public CompanyEmployeeAssembler companyEmployeeAssembler = new CompanyEmployeeAssembler();

        public CompanyDTO toCompanyDTO(Company company) {

            CompanyDTO companyDTO = new CompanyDTO();
            companyDTO.IdCompany = company.IdCompany;
            companyDTO.Name = company.Name;
            companyDTO.Logo = company.Logo;

            foreach (var employee in company.CompanyEmployees)
            {
                companyDTO.Employees.Add(companyEmployeeAssembler.toCompanyEmployeeForCompanyDTO(employee));
            }
            
            return companyDTO;
        }
        public CompanyForDashboardScreenDTO toCompanyForDashboardScreenDTO(Company company) {

            CompanyForDashboardScreenDTO companyDTO = new CompanyForDashboardScreenDTO();
            companyDTO.IdCompany = company.IdCompany;
            companyDTO.Name = company.Name;

            return companyDTO;
        }

        public Company toCompany(Company company, CompanyEditInputDTO companyEditInputDTO, int idPerson){

            company.Name = companyEditInputDTO.Name;
            company.Logo = companyEditInputDTO.Logo;

            foreach (CompanyEmployeeInputForPutCompany companyEmployee in companyEditInputDTO.employees)
            {
                if(companyEmployee.IdCompanyEmployee == null)
                    company.CompanyEmployees.Add(companyEmployeeAssembler.toCompanyEmployee(company, companyEmployee, idPerson));
            }
            return company;
        }

        public List<CompanyDTO> toCompanyDTO(IEnumerable<Company> companies) {

            List<CompanyDTO> companyDTO = new List<CompanyDTO>();

            foreach (Company company in companies) {
                companyDTO.Add(toCompanyDTO(company));
            }

            return companyDTO;
        }
        public List<CompanyForDashboardScreenDTO> toCompanyForDashboardScreenDTO(IEnumerable<Company> companies) {

            List<CompanyForDashboardScreenDTO> companyDTO = new List<CompanyForDashboardScreenDTO>();

            foreach (Company company in companies) {
                companyDTO.Add(toCompanyForDashboardScreenDTO(company));
            }

            return companyDTO;
        }

        public Company toCompany(CompanyInputDTO companyInputDTO, int idPerson) {

            Company company = new Company();
            company.Name = companyInputDTO.Name;
            company.Logo = companyInputDTO.Logo;

            foreach (CompanyEmployeeInputForPostCompany companyEmployee in companyInputDTO.employees)
            {
                company.CompanyEmployees.Add(companyEmployeeAssembler.toCompanyEmployee(company, companyEmployee, idPerson));
            }

            return company;
        }
    }
}

