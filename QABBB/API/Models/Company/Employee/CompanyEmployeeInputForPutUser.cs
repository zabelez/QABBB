using System;
namespace QABBB.API.Models.Company.Employee
{
    public class CompanyEmployeeInputForPutUser
    {
        public int? IdCompanyEmployee { get; set; } = null!;
        public int IdCompany { get; set; }
        public int IdPosition { get; set; }

    }
}