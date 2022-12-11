using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationController : ControllerBase
    {

        private readonly QABBBContext _context;

        public MigrationController(QABBBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("migration")]
        public ActionResult Migration()
        {
            string? jsonString = System.IO.File.ReadAllText("backup.json");
            MigrationRoot migration = JsonSerializer.Deserialize<MigrationRoot>(jsonString)!;
            
            foreach (KeyValuePair<string, MigrationEmail> item in migration.__collections__!.emailTemplates!)
            {
                EmailTemplate email = new EmailTemplate();
                email.Html = item.Value.html!;
                email.Subject = item.Value.subject!;
                email.Text = item.Value.text!;

                EmailTemplateServices emailTemplateServices = new EmailTemplateServices(_context);
                // emailTemplateServices.add(email);
            }

            
            List<string> users = new List<string>();
            foreach (KeyValuePair<string, MigrationUser> user in migration.__collections__.users!)
            {
                // if(user.Value.email != null)
                //     continue;

                string text = user.Value.text + " - ";
                text += user.Value.email;
                users.Add(text);
            }

            users.Sort();

            return Ok(users);
        }
    }

    public class MigrationRoot {
        public MigrationCollections? __collections__ { get; set; }
    }
    public class MigrationCollections {
        public Dictionary<string, MigrationEmail>? emailTemplates { get; set; }
        // public Publishers publishers { get; set; }
        // public TesterGroups testerGroups { get; set; }
        // public Testers testers { get; set; }
        public Dictionary<string, MigrationTests>? tests { get; set; }
        public Dictionary<string, MigrationUser>? users { get; set; }
    }

    public class MigrationTests{
        public string? developer { get; set; }
        public string? id { get; set; }
        public List<UploadedFile>? uploadedFiles { get; set; }
        public string? duration { get; set; }
        public string? name { get; set; }
        public List<Form>? forms { get; set; }
        public string? powerBiURL { get; set; }
        public string? spreadsheetURL { get; set; }
        public string? publisher { get; set; }
        public string? date { get; set; }
        public string? time { get; set; }
        public List<string>? platforms { get; set; }
        public string? cohortSize { get; set; }
        public List<SummaryDoc>? summaryDocs { get; set; }
        public string? logoURL { get; set; }
        public MigrationCollections? __collections__ { get; set; }
    }

    public class UploadedFile
    {
        public string? url { get; set; }
        public string? name { get; set; }
    }

    public class Form
    {
        public string? url { get; set; }
        public string? label { get; set; }
    }

    public class SummaryDoc
    {
        public string? label { get; set; }
        public string? url { get; set; }
    }

    public class MigrationUser {
        public bool? isAdmin { get; set; }
        public bool? isPasswordResetRequired { get; set; }
        public string? email { get; set; }
        public List<string>? publishers { get; set; }
        public string? id { get; set; }
        public string? text { get; set; }
        public MigrationCollections? __collections__ { get; set; }
    }

    public class MigrationEmail
    {
        public string? html { get; set; }
        public string? text { get; set; }
        public string? id { get; set; }
        public string? subject { get; set; }
        public MigrationCollections? __collections__ { get; set; }
    }
}