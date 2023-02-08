using System;
using QABBB.API.Models.Project;

namespace QABBB.API.Models.Company.Employee
{
    public class CompanyEmployeeForUserDTO
    {
        public int IdCompanyEmployee { get; set; }
        public int IdCompany { get; set; }
        public string? CompanyName {get; set;}
        public string? Position {get; set;}
        public DateTime CreatedAt { get; set; }
        public List<ProjectForUserDTO> projects { get; set; } = new List<ProjectForUserDTO>()!;
        
    }
}