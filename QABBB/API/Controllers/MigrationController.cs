using System;
using System.Security.Claims;
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
        MigrationRoot migration;
        int idPerson;

        public MigrationController(QABBBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("migration")]
        public ActionResult Migration()
        {
            string? jsonString = System.IO.File.ReadAllText("backup.json");
            migration = JsonSerializer.Deserialize<MigrationRoot>(jsonString)!;
            idPerson = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            List<EmailTemplate> emailTemplates = MEmailTemplates();
            List<Company> companies = MCompanies();
            List<User> users = MUsers(companies);

            List<Platform> platforms = MPlatform();
            // List<Game> games = MGame(companies, platforms);

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

        // private List<Game> MGame(List<Company> companies, List<Platform> platforms) {

        //     GameServices gameServices = new GameServices(_context);

        //     List<Game> games = new List<Game>();
        //     foreach (KeyValuePair<string, MigrationTests> migrationTest in migration.__collections__!.tests!){
        //         Game game = new Game();
        //         game.Name = migrationTest.Value.name!;
        //         game.Gamelogo = migrationTest.Value.logoURL;

        //         if(migrationTest.Value.developer != null){
        //             var MigrateCompany = migration.__collections__!.publishers![migrationTest.Value.developer];
        //             Company develop = companies.Find(company => company.Name == MigrateCompany.text)!;
        //             game.IdDeveloperNavigation = develop;
        //         }

        //         if(migrationTest.Value.publisher != null){
        //             var MigrateCompany = migration.__collections__!.publishers![migrationTest.Value.publisher];
        //             Company publisher = companies.Find(company => company.Name == MigrateCompany.text)!;
        //             game.IdPublisherNavigation = publisher;
        //         }

                
        //         foreach (string item in migrationTest.Value.platforms!) {
        //             Platform platform = platforms.Find(p => p.Name == item)!;
                    
        //             GamePlatform gamePlatform = new GamePlatform();
        //             gamePlatform.IdGameNavigation = game;
        //             gamePlatform.IdPlatformNavigation = platform;

        //             game.GamePlatforms.Add(gamePlatform);
        //         }
                
        //         gameServices.add(game);

        //         games.Add(game);
                    
        //     }
        //     return games;
        // }

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