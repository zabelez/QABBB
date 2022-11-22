using System;
namespace QABBB.API.Models.Developer.Employee
{
	public class DeveloperEmployeeDTO
	{
		public int IdDeveloperEmployee { get; set; }
        public string Company { get; set; }
        public string PersonName { get; set; }
        public string Position { get; set; }
        public string Status { get; set; } = null!;

	}
}

