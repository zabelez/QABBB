using System;
using System.ComponentModel.DataAnnotations;
namespace QABBB.API.Models.Developer
{
    public class DeveloperInputDTO
    {
        [Required]
        public int IdCompany { get; set; }

    }
}

