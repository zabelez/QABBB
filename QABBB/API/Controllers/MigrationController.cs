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
        private readonly UserServices _userServices;
        MigrationRoot migration;
        int idPerson = 0;
        
        public MigrationController(QABBBContext context)
        {
            _context = context;
            _userServices = new UserServices(_context);
        }

        [HttpGet]
        [Route("EnviromentTest")]
        public ActionResult EnviromentTest()
        {
            string? password = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return Ok(password);
        }

        [HttpGet]
        [Route("EmailResetPassword")]
        public async Task<ActionResult> EmailAsync(int idUser)
        {
            EmailServices emailServices = new EmailServices(_context);

            User user = _userServices.findById(idUser)!;

            await emailServices.ResetPassword(user);

            return Ok();
        }
        
        [HttpGet]
        [Route("EmailNewUserWelcome")]
        public async Task<ActionResult> EmailNewUser(int idUser)
        {
            EmailServices emailServices = new EmailServices(_context);

            User user = new User();

            await emailServices.NewUserWelcome(user);

            return Ok();
        }

        [HttpGet]
        [Route("migration")]
        public ActionResult Migration()
        {
            String query = "SET FOREIGN_KEY_CHECKS = 0;TRUNCATE TABLE `qabbb`.`admin`;TRUNCATE TABLE `qabbb`.`company`;TRUNCATE TABLE `qabbb`.`companyEmployee`;TRUNCATE TABLE `qabbb`.`companyEmployeePosition`;TRUNCATE TABLE `qabbb`.`emailTemplate`;TRUNCATE TABLE `qabbb`.`heatmap`;TRUNCATE TABLE `qabbb`.`heatmapLayer`;TRUNCATE TABLE `qabbb`.`person`;TRUNCATE TABLE `qabbb`.`platform`;TRUNCATE TABLE `qabbb`.`project`;TRUNCATE TABLE `qabbb`.`projectPlatform`;TRUNCATE TABLE `qabbb`.`projectDeveloper`;TRUNCATE TABLE `qabbb`.`projectFile`;TRUNCATE TABLE `qabbb`.`projectForm`;TRUNCATE TABLE `qabbb`.`projectPublisher`;TRUNCATE TABLE `qabbb`.`projectSummaryDoc`;TRUNCATE TABLE `qabbb`.`user`;TRUNCATE TABLE `qabbb`.`userPlatform`;SET FOREIGN_KEY_CHECKS = 1;INSERT INTO `qabbb`.`companyEmployeePosition` (`name`) VALUES ('Owner');INSERT INTO `qabbb`.`companyEmployeePosition` (`name`) VALUES ('Developer');INSERT INTO `qabbb`.`person` (`personName`, `email`) VALUES ('string', 'user@example.com');INSERT INTO `qabbb`.`user` (`idPerson`, `password`, `isPasswordResetRequired`, `isDarkMode`, `status`) VALUES ('1', '29B6775BAECA015A7EDF18D2780D46C00818103AB6BB278BC37B51C19AF488F21BED4F1349A2EB49501F0EA8EE98E34F5531B84A49123BB8CDEDE31533C6481C', '0', '1', 'Active');INSERT INTO `qabbb`.`admin` (`idUser`, `createdAt`, `createdBy`) VALUES ('1', '2022-11-11 11:11:11', '1');";

            _context.Database.ExecuteSqlRaw(query);

            string? jsonString = System.IO.File.ReadAllText("backup.json");
            migration = JsonSerializer.Deserialize<MigrationRoot>(jsonString)!;
            idPerson = 1;

            List<EmailTemplate> emailTemplates = MEmailTemplates();
            List<Company> companies = MCompanies();
            List<User> users = MUsers(companies);

            List<Platform> platforms = MPlatform();
            List<Project> projects = MProject(companies, platforms);

            return Ok();
        }

        [HttpGet]
        [Route("hashPassword/{password}")]
        public ActionResult HashPassword(string password)
        {
            PasswordServices passwordServices = new PasswordServices();
            return Ok(passwordServices.HashPasword(password));
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

                var formattedTime = "";
                switch (migrationTest.Value.time)
                {
                    case "1AM EST":
                        formattedTime = "01:00:00";
                        break;
                        
                    case "4 AM EST":
                        formattedTime = "04:00:00";
                        break;
                    
                    case "6AM EST":
                        formattedTime = "06:00:00";
                        break;
                        
                    case "7AM EDT":
                        formattedTime = "07:00:00";
                        break;
                        
                    case "10 AM CEST":
                    case "10AM EST":
                        formattedTime = "10:00:00";
                        break;
                        
                    case "10:30 AM CEST":
                        formattedTime = "10:30:00";
                        break;
                        
                    case "11":
                    case "11AM EDT":
                    case "11 AM EDT":
                        formattedTime = "11:00:00";
                        break;
                        
                    case "12PM EST":
                    case "12 PM EST":
                        formattedTime = "12:00:00";
                        break;
                    
                    case "12:30 PM EST":
                        formattedTime = "12:30:00";
                        break;
                    
                    case "1PM EST":
                    case "1PM EDT":
                    case "1 PM EDT":
                        formattedTime = "13:00:00";
                        break;
                        
                    case "2PM":
                    case "2PM EST":
                    case "2 PM EST":
                    case "2PM EDT":
                    case "2 PM EDT":
                        formattedTime = "14:00:00";
                        break;
                    
                    case "3PM EST":
                    case "3 PM EST":
                        formattedTime = "15:00:00";
                        break;
                    
                    case "6PM Local":
                        formattedTime = "18:00:00";
                        break;
                    
                    case "7PM EDT":
                        formattedTime = "19:00:00";
                        break;
                    
                    case "11 PM EST":
                        formattedTime = "23:00:00";
                        break;
                        
                    case "12:00 AM BST":
                    case "NA":
                    default:
                        formattedTime = "00:00:00";
                        break;

                }



                project.StartDateTime = migrationTest.Value.date == "" ? null : DateTime.Parse(migrationTest.Value.date + " " + formattedTime);
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
            EmailTemplateServices emailTemplateServices = new EmailTemplateServices(_context);

            foreach (KeyValuePair<string, MigrationEmail> item in migration.__collections__!.emailTemplates!)
            {
                EmailTemplate email = new EmailTemplate();
                email.Html = item.Value.html!;
                email.Subject = item.Value.subject!;
                email.Text = item.Value.text!;


                emailTemplateServices.add(email);
                emailTemplates.Add(email);
            }

            // Welcome User
            // EmailTemplate newUserEmailTemplate = new EmailTemplate();
            // newUserEmailTemplate.Text = "New User Welcome";
            // newUserEmailTemplate.Subject = "Welcome to %APP_NAME%";
            // newUserEmailTemplate.Html = "<!DOCTYPE html>< html >< head >  < meta name = \"viewport\" content = \"width=device-width,initial-scale=1\" >  < style >    body {            color: #fff;      padding: 50px;                font - family: 'Gill Sans, sans-seriff';                background - color: #2f3c4b;    }            p {                line - height: 18px;            }            a {            color: white;                font - weight: bold;            }  </ style ></ head >< body >  < h1 > Welcome to % APP_NAME %.</ h1 >  < p > You have been registered as a user on this site by someone within your organization.</ p >  < p >% APP_NAME % is DAQA’s proprietary online portal for viewing, downloading, and interacting with data gathered during test projects.</ p >  < p > Please bookmark the % APP_NAME % URL as it will be used to warehouse reports for past, present, and future test projects.</ p >  < p > If you have any questions or run into any difficulties with the site, please contact us at < a href = \"mailto:info@daqa.net\" > info@daqa.net </ a > and we will reply as soon as possible.</ p >  < p > Yours,< br >  DAQA </ p ></ body ></ html >";

            // emailTemplateServices.add(newUserEmailTemplate);
            // emailTemplates.Add(newUserEmailTemplate);

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
                user.IsPasswordResetRequired = true;
                user.Status = "Active";

                Person person = new Person();
                person.PersonName = item.Value.text!;
                person.Email = item.Value.email!;

                user.IdPersonNavigation = person;

                userServices.addCustomPassword(user, "123456");

                if(item.Value.company != null){
                    
                    var MigrateCompany = migration.__collections__!.publishers![item.Value.company];
                    Company company = companies.Find(company => company.Name == MigrateCompany.text)!;

                    CompanyEmployee companyEmployee = new CompanyEmployee();
                    companyEmployee.IdCompany = company.IdCompany;
                    companyEmployee.IdPerson = user.IdPerson;
                    companyEmployee.IdPosition = 2;

                    companyEmployeeServices.add(companyEmployee, idPerson);
                    
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

            List<Rename> renameList = new List<Rename>();
            renameList.Add(new Rename("Ubisoft", "Ubisoft - Far Cry 6"));
            renameList.Add(new Rename("Ubisoft", "Ubisoft - Watch Dogs"));

            foreach (KeyValuePair<string, MigrationPublishers> item in migration.__collections__!.publishers!)
            {
                Rename? rename = renameList.Find(i => i.from == item.Value.text);
                if(rename != null)
                    item.Value.text = rename.to;

                Company company = companies.Find(company => company.Name == item.Value.text)!;

                if(company == null) {
                    company = new Company();

                    
                    company.Name = item.Value.text!;
                    company.Logo = item.Value.logoURL;

                    CompanyServices companyServices = new CompanyServices(_context);
                    companyServices.add(company);

                    companies.Add(company);
                }
            }
            
            return companies;
        }
    }

    public class Rename {
        public string to;
        public string from;

        public Rename(string to, string from)
        {
            this.to = to;
            this.from = from;
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
        public string? company { get; set; }
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