using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QABBB.API.Assemblers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace QABBB.Domain.Services
{
    public class EmailServices
    {
        private readonly QABBBContext _context;

        public EmailServices(QABBBContext context) {
            _context = context;
        }

        async public Task ResetPassword(User user)
        {
            String subject = "Reset your password for QABBB";
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<!DOCTYPE html ><html lang =\"en\"><head>    <meta charset=\"UTF-8\">    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">    <title>Document</title></head><body>    <p>Hello,</p>    <p>Somebody requested a new password for the QABBB account associated with {0}.</p>    <p>No changes have been made to your account yet.</p>    <p>You can reset your password by clicking the link below:</p>    <p><a href=\"#\">https://www.qabbb.com/#/auth-management?mode=action&oobCode=code</a></p>        <p>If you did not request a new password, you can ignore this email.</p>        <p>Thanks,<br>    DAQA</p></body></html>",
                user.IdPersonNavigation.Email
            );

            await TesteEmail(subject, sb.ToString(), user);
        }

        async public Task NewUserWelcome(User user)
        {
            String subject = "Welcome to QABBB";
            String htmlContent = "<!DOCTYPE html><html lang=\"en\"><head>    <meta charset=\"UTF-8\">    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">    <title>Document</title></head><body>    <p>Hello,</p>    <p>Welcome to QABBB.</p>    <p>You have been registered as a user on this site by someone within your organization.</p>    <p>QABBB is DAQA’s proprietary online portal for viewing, downloading, and interacting with data gathered during test</p>    <p>projects.</p>    <p>Please bookmark the <a href=\"#\">QABBB URL</a> as it will be used to warehouse reports for past, present, and future test projects.</p>    <p>If you have any questions or run into any difficulties with the site, please contact us at info@daqa.net and we will</p>    <p>reply as soon as possible.</p>    <p>Yours,<br>    DAQA</p></body></html>";

            await TesteEmail(subject, htmlContent, user);
        }
        

        async private Task TesteEmail(String subject, String htmlContent, User user)
        {
            string? enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            EmailAddress to = new EmailAddress();

            if(enviroment == "Development")
                to = new EmailAddress("no-reply@daqa.net", "No Reply Test");
            else
                to = new EmailAddress(user.IdPersonNavigation.Email, user.IdPersonNavigation.PersonName);

            var apiKey = Environment.GetEnvironmentVariable("SendgridKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@daqa.net", "No Reply");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        
    }
}

