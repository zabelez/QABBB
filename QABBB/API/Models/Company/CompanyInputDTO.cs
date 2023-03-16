using System;
using System.ComponentModel.DataAnnotations;
using QABBB.API.Models.Company.Employee;

namespace QABBB.API.Models.Company
{
    public class CompanyInputDTO
    {
        [Required]
        public string Name { get; set; } = "";
        public string? Logo { get; set; }
        public List<CompanyEmployeeInputForPostCompany>? employees { get; set; } = new List<CompanyEmployeeInputForPostCompany>()!;

    }
}

