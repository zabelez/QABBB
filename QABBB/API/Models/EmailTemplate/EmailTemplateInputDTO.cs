using System;
using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.EmailTemplate
{
	public class EmailTemplateInputDTO
	{
        [Required]
        public string Html { get; set; } = null!;
        [Required]
        public string Text { get; set; } = null!;
        [Required]
        public string Subject { get; set; } = null!;
    }
}

