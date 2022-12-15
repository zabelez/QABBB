using System;
using System.ComponentModel.DataAnnotations;
namespace QABBB.API.Models.Company
{
    public class CompanyInputDTO
    {
        [Required]
        public string Name { get; set; } = "";
        public string? Logo { get; set; }
        public int CompanyParent { get; set; }

    }
}

