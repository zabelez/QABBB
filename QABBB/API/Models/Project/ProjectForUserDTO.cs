using System.ComponentModel.DataAnnotations;
using QABBB.API.Models.Company;
using QABBB.API.Models.Platform;
using QABBB.API.Models.ProjectFile;
using QABBB.API.Models.ProjectForm;
using QABBB.API.Models.Heatmap;
using QABBB.API.Models.ProjectSummaryDoc;
using QABBB.API.Models.ProjectPlatform;

namespace QABBB.API.Models.Project
{
    public class ProjectForUserDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string? Logo { get; set; } = null!;
        public DateTime? StartDateTime { get; set; }
        public decimal? Duration { get; set; }
        
    }

}
