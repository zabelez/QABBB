using System;
namespace QABBB.API.Models.Admin
{
	public class AdminDTO
	{
		public int IdAdmin { get; set; }
		public string PersonName { get; set; }
		public int IdUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? RemovedAt { get; set; }
        public string? RemovedBy { get; set; }
    }
}

