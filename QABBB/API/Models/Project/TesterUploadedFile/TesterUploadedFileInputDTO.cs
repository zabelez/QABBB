using System.ComponentModel.DataAnnotations;

namespace QABBB.API.Models.Project.TesterUploadedFile
{
    public class TesterUploadedFileInputDTO
    {
        public int IdProject { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        
    }
}
