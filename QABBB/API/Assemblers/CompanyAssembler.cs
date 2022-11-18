using System;
using QABBB.API.Models.Company;
using QABBB.API.Models.User;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class CompanyAssembler
    {

        public CompanyDTO toCompanyDTO(Company company) {

            CompanyDTO companyDTO = new CompanyDTO();
            companyDTO.IdCompany = company.IdCompany;
            companyDTO.Name = company.Name;
            companyDTO.Logo = company.Logo;
            
            return companyDTO;
        }

        // public User toUser(User user, EditUserDTO editUserDTO){
        //     user.UserName = editUserDTO.PersonName;
        //     user.IsDarkMode = editUserDTO.IsDarkMode;
        //     user.Status = editUserDTO.Status;
        //     user.IdPersonNavigation.PersonName = editUserDTO.PersonName;
        //     user.IdPersonNavigation.Email = editUserDTO.Email;
        //     return user;
        // }

        public List<CompanyDTO> toCompanyDTO(IEnumerable<Company> companies) {

            List<CompanyDTO> companyDTO = new List<CompanyDTO>();

            foreach (Company company in companies) {
                companyDTO.Add(toCompanyDTO(company));
            }

            return companyDTO;
        }

        // public LoginOUTDTO toLoginOUTDTO(User user, string token) {

        //     LoginOUTDTO newUser = new LoginOUTDTO();
        //     newUser.IdUser = user.IdPerson;
        //     newUser.UserName = user.UserName;
        //     newUser.IsDarkMode = user.IsDarkMode;
        //     newUser.Token = token;

        //     return newUser;
        // }

        public Company toCompany(CompanyInputDTO companyInputDTO) {

            Company company = new Company();
            company.Name = companyInputDTO.Name;
            company.Logo = companyInputDTO.Logo;

            return company;
        }
    }
}

