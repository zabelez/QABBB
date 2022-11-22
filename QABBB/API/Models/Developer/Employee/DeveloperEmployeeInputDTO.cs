using System;
namespace QABBB.API.Models.Developer.Employee
{
	public class DeveloperEmployeeInputDTO
	{
		public int IdDeveloper { get; set; }
        public int IdUser { get; set; }
        public int IdPosition { get; set; }
        public string Status { get; set; } = null!;

	}
}

