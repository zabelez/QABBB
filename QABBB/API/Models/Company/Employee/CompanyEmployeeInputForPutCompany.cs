using System;
namespace QABBB.API.Models.Company.Employee
{
    public class CompanyEmployeeInputForPutCompany
    {
        public int? IdCompanyEmployee { get; set; } = null!;
        public int IdPerson { get; set; }
        public int IdPosition { get; set; }

    }
}