using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Company;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DocumentController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly HttpClient _httpClient;
        private readonly DocumentServices _documentServices;

        public DocumentController(QABBBContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
            _documentServices = new DocumentServices(_context);
        }

        // GET: api/Document/5
        [HttpGet("{uuid}")]
        public async Task<IActionResult> GetDocument(string uuid)
        {
            Document document = _documentServices.findByUuid(uuid);

            if (document == null)
                return NotFound();

            var response = await _httpClient.GetAsync(document.Url);

            if (!response.IsSuccessStatusCode)
                return new NotFoundResult();

            var content = await response.Content.ReadAsByteArrayAsync();

            var contentType = "application/octet-stream";

            var fileName = "";

            if (response.Content.Headers.TryGetValues("Content-Disposition", out var values))
            {
                var contentDisposition = ContentDispositionHeaderValue.Parse(values.First());
                fileName = contentDisposition.FileNameStar;
            } else {
                fileName = "Noname";
            }

            return new FileContentResult(content, contentType)
            {
                FileDownloadName = Path.GetFileName(fileName)
            };
        }
    }
}
