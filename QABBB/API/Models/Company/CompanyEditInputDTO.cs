using System;
using System.ComponentModel.DataAnnotations;
using QABBB.API.Models.Company.Employee;

namespace QABBB.API.Models.Company
{
    public class CompanyEditInputDTO
    {
        [Required]
        public int IdCompany {get; set;}
        [Required]
        public string Name { get; set; } = "";
        public string Logo {get; set;} = "";
        public List<CompanyEmployeeInputForPutCompany>? employees { get; set; } = new List<CompanyEmployeeInputForPutCompany>()!;

    }
}

