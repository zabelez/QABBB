using System;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        MigrationRoot migration;
        int idPerson = 0;
        
        public MigrationController(QABBBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("migration")]
        public ActionResult Migration()
        {
            String query = "SET FOREIGN_KEY_CHECKS = 0;TRUNCATE TABLE `qabbb`.`admin`;TRUNCATE TABLE `qabbb`.`company`;TRUNCATE TABLE `qabbb`.`companyEmployee`;TRUNCATE TABLE `qabbb`.`companyEmployeePosition`;TRUNCATE TABLE `qabbb`.`emailTemplate`;TRUNCATE TABLE `qabbb`.`heatmap`;TRUNCATE TABLE `qabbb`.`heatmapLayer`;TRUNCATE TABLE `qabbb`.`person`;TRUNCATE TABLE `qabbb`.`platform`;TRUNCATE TABLE `qabbb`.`project`;TRUNCATE TABLE `qabbb`.`projectPlatform`;TRUNCATE TABLE `qabbb`.`projectDeveloper`;TRUNCATE TABLE `qabbb`.`projectFile`;TRUNCATE TABLE `qabbb`.`projectForm`;TRUNCATE TABLE `qabbb`.`projectPublisher`;TRUNCATE TABLE `qabbb`.`projectSummaryDoc`;TRUNCATE TABLE `qabbb`.`user`;TRUNCATE TABLE `qabbb`.`userPlatform`;SET FOREIGN_KEY_CHECKS = 1;INSERT INTO `qabbb`.`companyEmployeePosition` (`name`) VALUES ('Owner');INSERT INTO `qabbb`.`companyEmployeePosition` (`name`) VALUES ('Developer');INSERT INTO `qabbb`.`person` (`personName`, `email`) VALUES ('string', 'user@example.com');INSERT INTO `qabbb`.`user` (`idPerson`, `password`, `isPasswordResetRequired`, `isDarkMode`, `status`) VALUES ('1', 'string', '0', '1', 'Active');";

            _context.Database.ExecuteSqlRaw(query);

            string? jsonString = System.IO.File.ReadAllText("backup.json");
            migration = JsonSerializer.Deserialize<MigrationRoot>(jsonString)!;
            idPerson = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            List<EmailTemplate> emailTemplates = MEmailTemplates();
            List<Company> companies = MCompanies();
            List<User> users = MUsers(companies);

            List<Platform> platforms = MPlatform();
            List<Project> projects = MProject(companies, platforms);

            return Ok();
        }

        private List<Platform> MPlatform() {

            PlatformServices platformServices = new PlatformServices(_context);

            List<Platform> platforms = new List<Platform>();
            foreach (KeyValuePair<string, MigrationTests> migrationTest in migration.__collections__!.tests!)
            {
                foreach (string migrationPlatform in migrationTest.Value.platforms!)
                {
                    if(platforms.FindIndex(p => p.Name == migrationPlatform) == -1){
                        Platform platform = new Platform();
                        platform.Name = migrationPlatform;

                        platformServices.add(platform);

                        platforms.Add(platform);
                    }
                }
            }
            return platforms;
        }

        private List<Project> MProject(List<Company> companies, List<Platform> platforms) {

            ProjectServices projectServices = new ProjectServices(_context);

            List<Project> projects = new List<Project>();

            foreach (KeyValuePair<string, MigrationTests> migrationTest in migration.__collections__!.tests!){
                Project project = new Project();
                project.Name = migrationTest.Value.name!;
                project.Logo = migrationTest.Value.logoURL;
                project.StartDateTime = migrationTest.Value.date == "" ? null : DateTime.Parse(migrationTest.Value.date);
                project.Duration = Decimal.Parse(migrationTest.Value.duration == "" ? "0" : migrationTest.Value.duration);
                project.PowerBiUrl = migrationTest.Value.powerBiURL;
                project.SpreadsheetUrl = migrationTest.Value.spreadsheetURL;

                if(migrationTest.Value.developer != null){
                    var MigrateCompany = migration.__collections__!.publishers![migrationTest.Value.developer];
                    Company develop = companies.Find(company => company.Name == MigrateCompany.text)!;
                    ProjectDeveloper projectDeveloper = new ProjectDeveloper();
                    projectDeveloper.IdCompanyNavigation = develop;
                    projectDeveloper.IdProjectNavigation = project;
                    project.ProjectDevelopers.Add(projectDeveloper);
                }

                if(migrationTest.Value.publisher != null){
                    var MigrateCompany = migration.__collections__!.publishers![migrationTest.Value.publisher];
                    Company publisher = companies.Find(company => company.Name == MigrateCompany.text)!;
                    ProjectPublisher projectPublisher = new ProjectPublisher();
                    projectPublisher.IdCompanyNavigation = publisher;
                    projectPublisher.IdProjectNavigation = project;
                    project.ProjectPublishers.Add(projectPublisher);
                }

                foreach (string item in migrationTest.Value.platforms!) {
                    Platform platform = platforms.Find(p => p.Name == item)!;
                    ProjectPlatform projectPlatform = new ProjectPlatform();
                    projectPlatform.IdPlatformNavigation = platform;
                    projectPlatform.IdProjectNavigation = project;
                    projectPlatform.CohortSize = Int16.Parse(migrationTest.Value.cohortSize == "" ? "0" : migrationTest.Value.cohortSize);

                    project.ProjectPlatforms.Add(projectPlatform);
                }

                foreach (Files item in migrationTest.Value.summaryDocs ?? new List<Files>()) {
                    ProjectSummaryDoc projectSummaryDoc = new ProjectSummaryDoc();
                    projectSummaryDoc.Url = item.url == null ? "No name" : item.url;
                    projectSummaryDoc.Label = item.label == null ? "No name" : item.label;
                    project.ProjectSummaryDocs.Add(projectSummaryDoc);
                }

                foreach (Files2 item in migrationTest.Value.uploadedFiles ?? new List<Files2>()) {
                    ProjectFile projectFile = new ProjectFile();
                    projectFile.Url = item.url == null ? "No name" : item.url;
                    projectFile.Name = item.name == null ? "No name" : item.name;
                    project.ProjectFiles.Add(projectFile);
                }
                
                foreach (Files item in migrationTest.Value.forms ?? new List<Files>()) {
                    ProjectForm projectForm = new ProjectForm();
                    projectForm.Url = item.url == null ? "No name" : item.url;
                    projectForm.Name = item.label == null ? "No name" : item.label;
                    project.ProjectForms.Add(projectForm);
                }
                
                projectServices.add(project);

                projects.Add(project);
                    
            }
            return projects;
        }

        private List<EmailTemplate> MEmailTemplates(){

            List<EmailTemplate> emailTemplates = new List<EmailTemplate>();
            foreach (KeyValuePair<string, MigrationEmail> item in migration.__collections__!.emailTemplates!)
            {
                EmailTemplate email = new EmailTemplate();
                email.Html = item.Value.html!;
                email.Subject = item.Value.subject!;
                email.Text = item.Value.text!;

                EmailTemplateServices emailTemplateServices = new EmailTemplateServices(_context);

                emailTemplateServices.add(email);
                emailTemplates.Add(email);
            }

            return emailTemplates;

        }

        private List<User> MUsers(List<Company> companies){

            UserServices userServices = new UserServices(_context);
            AdminServices adminServices = new AdminServices(_context);
            CompanyEmployeeServices companyEmployeeServices = new CompanyEmployeeServices(_context);

            List<User> users = new List<User>();
            foreach (KeyValuePair<string, MigrationUser> item in migration.__collections__!.users!)
            {
                if(item.Value.email == null)
                    continue;

                User user = new User();
                user.IsDarkMode = item.Value.isDarkMode;
                user.IsPasswordResetRequired = item.Value.isPasswordResetRequired;
                user.Status = "Active";

                Person person = new Person();
                person.PersonName = item.Value.text!;
                person.Email = item.Value.email!;

                user.IdPersonNavigation = person;

                userServices.add(user);

                if(item.Value.publishers!.Count > 0){
                    List<string> companyTokens = new List<string>();

                    foreach (var tokenCompany in item.Value.publishers)
                    {
                        companyTokens.Add(tokenCompany);
                        var MigrateCompany = migration.__collections__!.publishers![tokenCompany];
                        Company company = companies.Find(company => company.Name == MigrateCompany.text)!;

                        CompanyEmployee companyEmployee = new CompanyEmployee();
                        companyEmployee.IdCompany = company.IdCompany;
                        companyEmployee.IdPerson = user.IdPerson;
                        companyEmployee.IdPosition = 2;

                        companyEmployeeServices.add(companyEmployee, idPerson);
                    }
                }

                if(item.Value.isAdmin == true){
                    Admin admin = new Admin();
                    admin.IdUser = user.IdPerson;
                    
                    adminServices.add(admin, idPerson);
                }

                users.Add(user);

            }

            return users;
            
        }

        private List<Company> MCompanies(){
            List<Company> companies = new List<Company>();
            foreach (KeyValuePair<string, MigrationPublishers> item in migration.__collections__!.publishers!)
            {
                Company company = new Company();
                company.Name = item.Value.text!;
                company.Logo = item.Value.logoURL;

                CompanyServices companyServices = new CompanyServices(_context);
                companyServices.add(company);

                companies.Add(company);
            }
            
            return companies;
        }
    }


    public class MigrationRoot {
        public MigrationCollections? __collections__ { get; set; }
    }
    public class MigrationCollections {
        public Dictionary<string, MigrationEmail>? emailTemplates { get; set; }
        public Dictionary<string, MigrationPublishers>? publishers { get; set; }
        // public TesterGroups testerGroups { get; set; }
        // public Testers testers { get; set; }
        public Dictionary<string, MigrationTests>? tests { get; set; }
        public Dictionary<string, MigrationUser>? users { get; set; }
    }

    public class MigrationTests{
        public string? developer { get; set; }
        public string? id { get; set; }
        public string? logoURL { get; set; }
        public string? duration { get; set; }
        public string? name { get; set; }
        public string? powerBiURL { get; set; }
        public string? spreadsheetURL { get; set; }
        public string? publisher { get; set; }
        public string? date { get; set; }
        public string? time { get; set; }
        public List<string>? platforms { get; set; }
        public string? cohortSize { get; set; }
        public List<Files>? forms { get; set; }
        public List<Files2>? uploadedFiles { get; set; }
        public List<Files>? summaryDocs { get; set; }
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

    public class Files
    {
        public string? label { get; set; }
        public string? url { get; set; }
    }

    public class Files2
    {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class MigrationUser {
        public bool? isAdmin { get; set; }
        public bool isPasswordResetRequired { get; set; } = false!;
        public string? email { get; set; }
        public List<string>? publishers { get; set; }
        public string? id { get; set; }
        public string? text { get; set; }
        public bool isDarkMode { get; set;} = false!;
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

    public class MigrationPublishers
    {
        public string? text { get; set; }
        public string? id { get; set; }
        public string? logoURL { get; set; }
        public MigrationCollections? __collections__ { get; set; }
    }

    public class MigrationUploadedfiles {
        public string? name { get; set; }
        public string? url { get; set; }
    }

    public class MigrationForms {
        public string? name { get; set; }
        public string? url { get; set; }
    }

}