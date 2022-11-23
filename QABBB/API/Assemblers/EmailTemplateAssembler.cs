using System;
using QABBB.API.Models.EmailTemplate;
using QABBB.API.Models.User;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class EmailTemplateAssembler
    {

        public EmailTemplateDTO toEmailTemplateDTO(EmailTemplate emailTemplate) {

            EmailTemplateDTO emailTemplateDTO = new EmailTemplateDTO();
            emailTemplateDTO.IdEmailTemplate = emailTemplate.IdEmailTemplate;
            emailTemplateDTO.Html = emailTemplate.Html;
            emailTemplateDTO.Text = emailTemplate.Text;
            emailTemplateDTO.Subject = emailTemplate.Subject;
            
            return emailTemplateDTO;
        }

        public EmailTemplate toEmailTemplate(EmailTemplate emailTemplate, EmailTemplateEditDTO emailTemplateEditInputDTO){
            emailTemplate.IdEmailTemplate = emailTemplateEditInputDTO.IdEmailTemplate;
            emailTemplate.Html = emailTemplateEditInputDTO.Html;
            emailTemplate.Text = emailTemplateEditInputDTO.Text;
            emailTemplate.Subject = emailTemplateEditInputDTO.Subject;

            return emailTemplate;
        }

        public List<EmailTemplateDTO> toEmailTemplateDTO(IEnumerable<EmailTemplate> companies) {

            List<EmailTemplateDTO> emailTemplateDTO = new List<EmailTemplateDTO>();

            foreach (EmailTemplate emailTemplate in companies) {
                emailTemplateDTO.Add(toEmailTemplateDTO(emailTemplate));
            }

            return emailTemplateDTO;
        }

        public EmailTemplate toEmailTemplate(EmailTemplateInputDTO emailTemplateInputDTO) {

            EmailTemplate emailTemplate = new EmailTemplate();
            emailTemplate.Html = emailTemplateInputDTO.Html;
            emailTemplate.Text = emailTemplateInputDTO.Text;
            emailTemplate.Subject = emailTemplateInputDTO.Subject;

            return emailTemplate;
        }
    }
}

