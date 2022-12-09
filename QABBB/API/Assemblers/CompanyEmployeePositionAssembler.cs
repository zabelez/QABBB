using System;
using QABBB.API.Models.Company.Employee.Position;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class CompanyEmployeePositionAssembler
    {

        public CompanyEmployeePositionDTO toCompanyEmployeePositionDTO(CompanyEmployeePosition companyEmployeePosition) {

            CompanyEmployeePositionDTO companyEmployeePositionDTO = new CompanyEmployeePositionDTO();
            companyEmployeePositionDTO.IdCompanyEmployeePosition = companyEmployeePosition.IdCompanyEmployeePosition;
            companyEmployeePositionDTO.Name = companyEmployeePosition.Name;

            return companyEmployeePositionDTO;
        }

        public List<CompanyEmployeePositionDTO> toCompanyEmployeePositionDTO(IEnumerable<CompanyEmployeePosition> companyEmployeePositions) {

            List<CompanyEmployeePositionDTO> companyEmployeeDTOs = new List<CompanyEmployeePositionDTO>();

            foreach (CompanyEmployeePosition companyEmployeePosition in companyEmployeePositions) {
                companyEmployeeDTOs.Add(toCompanyEmployeePositionDTO(companyEmployeePosition));
            }

            return companyEmployeeDTOs;
        }
    }
}

