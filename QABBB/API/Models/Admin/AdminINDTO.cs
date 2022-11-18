using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Admin
{
	public class AdminINDTO
	{
		[Required]
		public int IdPerson { get; set; }
	}
}

