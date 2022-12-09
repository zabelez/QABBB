using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class CompanyEmployee
    {
        public int IdCompanyEmployee { get; set; }
        public int IdCompany { get; set; }
        public int IdPerson { get; set; }
        public int IdPosition { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? RemovedAt { get; set; }
        public int? RemovedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; } = null!;
        public virtual Company IdCompanyNavigation { get; set; } = null!;
        public virtual User IdPersonNavigation { get; set; } = null!;
        public virtual CompanyEmployeePosition IdPositionNavigation { get; set; } = null!;
        public virtual User? RemovedByNavigation { get; set; }
    }
}
