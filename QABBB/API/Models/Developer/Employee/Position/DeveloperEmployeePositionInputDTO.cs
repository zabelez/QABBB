using System;
using System.ComponentModel.DataAnnotations;
namespace QABBB.API.Models.Developer.Employee
{
    public class DeveloperEmployeePositionInputDTO
    {
        [Required]
        public string Name { get; set; }

    }
}
