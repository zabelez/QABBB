using System;
namespace QABBB.API.Models.EmailTemplate
{
	public class EmailTemplateDTO
	{
        public int IdEmailTemplate { get; set; }
        public string Html { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string Subject { get; set; } = null!;
    }
}

