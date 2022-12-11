using System;
using System.ComponentModel.DataAnnotations;
namespace QABBB.API.Models.Company
{
    public class CompanyEditInputDTO
    {
        [Required]
        public int IdCompany {get; set;}
        [Required]
        public string Name { get; set; } = "";
        public string Logo {get; set;} = "";

    }
}

