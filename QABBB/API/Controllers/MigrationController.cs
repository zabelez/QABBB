using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MigrationController : ControllerBase
    {
        [HttpGet]
        [Route("migration")]
        public ActionResult Migration()
        {
            string? text = System.IO.File.ReadAllText("backup.json");
            JsonNode json = JsonNode.Parse(text)!;
            var options = new JsonSerializerOptions { WriteIndented = true };
            var migration = json!.ToJsonString(options);

            return Ok(migration);
        }
    }

    public class MigrationModel
    {
        List<String>? emailTemplates { get; set; }
        List<String>? publishers { get; set; }
        List<String>? testerGroups { get; set; }
        List<String>? testers { get; set; }
        List<String>? tests { get; set; }
        List<String>? users { get; set; }
    }

}
