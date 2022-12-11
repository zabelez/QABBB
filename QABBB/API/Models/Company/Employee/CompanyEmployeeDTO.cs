using System;
namespace QABBB.API.Models.Company.Employee
{
    public class CompanyEmployeeDTO
    {
        public int IdCompanyEmployee { get; set; }
        public int IdCompany { get; set; }
        public string? CompanyName {get; set;}
        public int IdPerson { get; set; }
        public string? PersonName {get; set;}
        public string? Position {get; set;}
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public string? CreatedByName {get; set;}
        public DateTime? RemovedAt { get; set; }
        public int? RemovedBy { get; set; }
        public string? RemovedByName {get; set;}

    }
}