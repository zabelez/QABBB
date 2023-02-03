using System;
using QABBB.API.Models.Company.Employee;

namespace QABBB.API.Models.Company
{
    public class CompanyDTO
    {
        public int IdCompany { get; set; }
        public string? Name { get; set; }
        public string? Logo {get; set;}
        public List<CompanyEmployeeForCompanyDTO> Employees {get; set;} = new List<CompanyEmployeeForCompanyDTO>();
    }

}