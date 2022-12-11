using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.User
{
	public class ResetPasswordRequiredDTO
	{
		[Required]
		public string? UserName { get; set; }
        [Required]
		public string? OldPassword { get; set; }
        [Required]
		public string? NewPassword { get; set; }
	}
}

