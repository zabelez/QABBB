using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Project;
using QABBB.API.Models.ProjectDeveloper;
using QABBB.API.Models.Link;
using QABBB.API.Models.ProjectPlatform;
using QABBB.API.Models.ProjectPublisher;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProjectController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly ProjectServices _projectServices;
        private readonly ProjectAssembler _projectAssembler;

        public ProjectController(QABBBContext context)
        {
            _context = context;
            _projectServices = new ProjectServices(_context);
            _projectAssembler = new ProjectAssembler();
        }

        // GET: api/Project
        [HttpGet]
        public ActionResult<List<ProjectForDashboardScreenDTO>> GetProjects()
        {
            if (_context.Projects == null)
                return NotFound();

            List<Project> projects = _projectServices.list();

            List<ProjectForDashboardScreenDTO> projectDTOs = _projectAssembler.toProjectForDashboardScreenDTO(projects);
          
            return Ok(projectDTOs);
        }

        // GET: api/Project/byUser/{id}
        [HttpGet("byUser/{id}")]
        public ActionResult<List<ProjectForDashboardScreenDTO>> GetProjectsByUser(int id)
        {
            if (_context.Projects == null)
                return NotFound();

            List<Project> projects = _projectServices.listByUser(id);

            List<ProjectForDashboardScreenDTO> projectDTOs = _projectAssembler.toProjectForDashboardScreenDTO(projects);

            return Ok(projectDTOs);
        }

        // GET: api/Project/byCompany/{id}
        [HttpGet("byCompany/{id}")]
        public ActionResult<List<ProjectForDashboardScreenDTO>> GetProjectsByCompany(int id)
        {
            if (_context.Projects == null)
                return NotFound();

            List<Project> projects = _projectServices.listByCompany(id);

            List<ProjectForDashboardScreenDTO> projectDTOs = _projectAssembler.toProjectForDashboardScreenDTO(projects);

            return Ok(projectDTOs);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public ActionResult<ProjectFullDTO> GetProject(int id)
        {
            if (_context.Projects == null)
                return NotFound();
          
            Project? project = _projectServices.findById(id);
            if(project == null)
                return NotFound();

            ProjectFullDTO projectDTO = _projectAssembler.toProjectFullDTO(project);

            return Ok(projectDTO);
        }

        // PUT: api/Project/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public ActionResult PutProject(ProjectEditDTO projectEditDTO)
        {
            ProjectDeveloperServices pdServices = new ProjectDeveloperServices(_context);

            Project? project = _projectServices.findById(projectEditDTO.IdProject);
            if(project == null)
                return NotFound();

            using var transaction = _context.Database.BeginTransaction();

            _projectAssembler.toProject(project, projectEditDTO);
            
            _projectServices.edit(project, projectEditDTO);

            transaction.Commit();
            
            return NoContent();
        }

        // POST: api/Project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<ProjectDTO> PostProject(ProjectInputDTO projectInputDTO)
        {
            using var transaction = _context.Database.BeginTransaction();

            CompanyServices companyServices = new CompanyServices(_context);
            PlatformServices platformServices = new PlatformServices(_context);

            if (_context.Projects == null)
                return Problem("Entity set 'QABBBContext.Projects'  is null.");

            Project project = _projectAssembler.toProject(projectInputDTO);

            foreach (ProjectDeveloperInputDTOForPostProject developer in projectInputDTO.Developers)
            {
                ProjectDeveloper projectDeveloper = new ProjectDeveloper();
                projectDeveloper.IdProjectNavigation = project;
                projectDeveloper.IdCompanyNavigation = companyServices.findById(developer.IdCompany);
                project.ProjectDevelopers.Add(projectDeveloper);
            }

            foreach (ProjectPublisherInputDTOForPostProject publisher in projectInputDTO.Publishers)
            {
                ProjectPublisher projectPublisher = new ProjectPublisher();
                projectPublisher.IdProjectNavigation = project;
                projectPublisher.IdCompanyNavigation = companyServices.findById(publisher.IdCompany);
                project.ProjectPublishers.Add(projectPublisher);
            }

            foreach (ProjectPlatformInputDTOForPostProject platform in projectInputDTO.ProjectPlatforms)
            {
                ProjectPlatform projectPlatform = new ProjectPlatform();
                projectPlatform.IdProjectNavigation = project;
                projectPlatform.CohortSize = platform.CohortSize;
                projectPlatform.IdPlatformNavigation = platformServices.findById(platform.IdPlatform);
                project.ProjectPlatforms.Add(projectPlatform);
            }

            // foreach (ProjectFileInputDTOForPostProject file in projectInputDTO.ProjectFiles)
            // {
            //     ProjectFile projectFile = new ProjectFile();
            //     projectFile.DocumentNavigation = new Document();

            //     projectFile.IdProjectNavigation = project;
            //     projectFile.DocumentNavigation.Label = file.Name;
            //     projectFile.DocumentNavigation.Link = file.Url;
            //     projectFile.DocumentNavigation.DocumentStorage = file.DocumentStorage;
            //     project.ProjectFiles.Add(projectFile);
            // }

            // foreach (LinkInputDTOForPostProject form in projectInputDTO.Links)
            // {
            //     Link link = new Link();
            //     link.DocumentNavigation = new Document();

            //     link.IdProjectNavigation = project;
            //     link.DocumentNavigation.Label = form.Name;
            //     link.DocumentNavigation.Link = form.Url;
            //     link.DocumentNavigation.DocumentStorage = form.DocumentStorage;
            //     project.Links.Add(link);
            // }

            // foreach (ProjectSummaryDocInputDTOForPostProject form in projectInputDTO.ProjectSummaryDocs)
            // {
            //     ProjectSummaryDoc projectSummaryDoc = new ProjectSummaryDoc();
            //     projectSummaryDoc.DocumentNavigation = new Document();

            //     projectSummaryDoc.IdProjectNavigation = project;
            //     projectSummaryDoc.DocumentNavigation.Label = form.Label;
            //     projectSummaryDoc.DocumentNavigation.Link = form.Url;
            //     projectSummaryDoc.DocumentNavigation.DocumentStorage = form.DocumentStorage;
            //     project.ProjectSummaryDocs.Add(projectSummaryDoc);
            // }

            // foreach (ProjectInterviewInputDTOForPostProject file in projectInputDTO.ProjectInterviews)
            // {
            //     ProjectInterview projectInterview = new ProjectInterview();
            //     projectInterview.DocumentNavigation = new Document();

            //     projectInterview.IdProjectNavigation = project;
            //     projectInterview.DocumentNavigation.Label = file.Name;
            //     projectInterview.DocumentNavigation.Link = file.Url;
            //     projectInterview.DocumentNavigation.DocumentStorage = file.DocumentStorage;
            //     project.ProjectInterviews.Add(projectInterview);
            // }

            _projectServices.add(project);

            transaction.Commit();

            ProjectFullDTO projectDTO = _projectAssembler.toProjectFullDTO(project);

            return CreatedAtAction("GetProject", new { id = projectDTO.IdProject }, projectDTO);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProject(int id)
        {
            if (_context.Projects == null)
                return NotFound();
            
            Project? project = _projectServices.findById(id);
            if(project == null)
                return NotFound();

            _projectServices.delete(project);

            return NoContent();
        }
    }
}
