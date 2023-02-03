using System;
namespace QABBB.API.Models.Company.Employee
{
    public class CompanyEmployeeForCompanyDTO
    {
        public int IdCompanyEmployee { get; set; }
        public int IdPerson { get; set; }
        public string? PersonName {get; set;}
        public string? Position {get; set;}
        public DateTime CreatedAt { get; set; }
    }
}