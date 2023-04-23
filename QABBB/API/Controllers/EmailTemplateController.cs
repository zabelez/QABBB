using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.EmailTemplate;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmailTemplateController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly EmailTemplateServices _emailTemplateServices;
        private readonly EmailTemplateAssembler _emailTemplateAssembler;

        public EmailTemplateController(QABBBContext context)
        {
            _context = context;
            _emailTemplateServices = new EmailTemplateServices(_context);
            _emailTemplateAssembler = new EmailTemplateAssembler();
        }

        // GET: api/EmailTemplate
        [HttpGet]
        public ActionResult<List<EmailTemplateDTO>> GetEmailTemplates()
        {
            if (_context.EmailTemplates == null)
                return NotFound();

            List<EmailTemplate> emailTemplates = _emailTemplateServices.list();

            List<EmailTemplateDTO> emailTemplateDTOs = _emailTemplateAssembler.toEmailTemplateDTO(emailTemplates);
          
            return Ok(emailTemplateDTOs);
        }

        // GET: api/EmailTemplate/5
        [HttpGet("{id}")]
        public ActionResult<EmailTemplateDTO> GetEmailTemplate(int id)
        {
            if (_context.EmailTemplates == null)
                return NotFound();
          
            EmailTemplate? emailTemplate = _emailTemplateServices.findById(id);
            if(emailTemplate == null)
                return NotFound();

            EmailTemplateDTO emailTemplateDTO = _emailTemplateAssembler.toEmailTemplateDTO(emailTemplate);

            return Ok(emailTemplateDTO);
        }

        // PUT: api/EmailTemplate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public ActionResult PutEmailTemplate(EmailTemplateEditDTO emailTemplateEditDTO)
        {
            EmailTemplate? emailTemplate = _emailTemplateServices.findById(emailTemplateEditDTO.IdEmailTemplate);
            if(emailTemplate == null)
                return NotFound();

            _emailTemplateAssembler.toEmailTemplate(emailTemplate, emailTemplateEditDTO);
            
            _emailTemplateServices.edit(emailTemplate);
            
            return NoContent();
        }

        // POST: api/EmailTemplate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<EmailTemplateDTO> PostEmailTemplate(EmailTemplateInputDTO emailTemplateInputDTO)
        {
            if (_context.EmailTemplates == null)
                return Problem("Entity set 'QABBBContext.EmailTemplates'  is null.");

            EmailTemplate emailTemplate = _emailTemplateAssembler.toEmailTemplate(emailTemplateInputDTO);

            _emailTemplateServices.add(emailTemplate);

            EmailTemplateDTO emailTemplateDTO = _emailTemplateAssembler.toEmailTemplateDTO(emailTemplate);

            return CreatedAtAction("GetEmailTemplate", new { id = emailTemplateDTO.IdEmailTemplate }, emailTemplateDTO);
        }

        // DELETE: api/EmailTemplate/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEmailTemplate(int id)
        {
            if (_context.EmailTemplates == null)
                return NotFound();
            
            EmailTemplate? emailTemplate = _emailTemplateServices.findById(id);
            if(emailTemplate == null)
                return NotFound();

            _emailTemplateServices.delete(emailTemplate);

            return NoContent();
        }
    }
}
