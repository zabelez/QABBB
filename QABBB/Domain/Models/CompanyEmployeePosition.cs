using System;
using System.Collections.Generic;

namespace QABBB.Models
{
    public partial class CompanyEmployeePosition
    {
        public CompanyEmployeePosition()
        {
            CompanyEmployees = new HashSet<CompanyEmployee>();
        }

        public int IdCompanyEmployeePosition { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; }
    }
}
