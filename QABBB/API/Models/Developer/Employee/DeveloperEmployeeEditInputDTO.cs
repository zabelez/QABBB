using System;
namespace QABBB.API.Models.Developer.Employee
{
	public class DeveloperEmployeeEditInputDTO
	{
		public int IdDeveloperEmployee { get; set; }
        public int IdPosition { get; set; }
        public string Status { get; set; } = null!;

	}
}

