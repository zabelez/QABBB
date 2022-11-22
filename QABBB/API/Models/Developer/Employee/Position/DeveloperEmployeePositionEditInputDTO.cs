using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Developer.Employee
{
	public class DeveloperEmployeePositionEditInputDTO
	{
		[Required]
        public int IdPosition {get; set;}
        [Required]
        public string Name { get; set; }

	}
}

