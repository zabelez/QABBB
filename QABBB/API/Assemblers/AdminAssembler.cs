using System;
using QABBB.API.Models.Admin;
using QABBB.API.Models.User;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
	public class AdminAssembler
	{
		public AdminDTO toAdminDTO(Admin admin)
		{
			AdminDTO adminDTO = new AdminDTO();
			adminDTO.IdAdmin = admin.IdAdmin;
			adminDTO.IdUser = admin.IdUser;
			adminDTO.PersonName = admin.IdUserNavigation.IdPersonNavigation.PersonName;
			adminDTO.CreatedAt = admin.CreatedAt;
			adminDTO.CreatedBy = admin.CreatedByNavigation.IdPersonNavigation.PersonName;
			adminDTO.RemovedAt = admin.RemovedAt;
			adminDTO.RemovedBy = admin.RemovedByNavigation?.IdPersonNavigation.PersonName;

			return adminDTO;
		}

        public List<AdminDTO> toAdminDTO(IEnumerable<Admin> admins)
        {
            List<AdminDTO> newAdmins = new List<AdminDTO>();

            foreach (Admin admin in admins)
            {
				AdminDTO? adminDTO = this.toAdminDTO(admin);
				if(adminDTO != null)
                	newAdmins.Add(adminDTO);
            }

            return newAdmins;
        }

		public Admin toAdmin(AdminINDTO adminINDTO, User user)
		{
			Admin admin = new Admin();
			admin.IdUser = adminINDTO.IdPerson;
			return admin;
		}
    }
}

