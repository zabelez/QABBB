using System;
using QABBB.API.Models.Heatmap;

namespace QABBB.API.Models.ProjectPlatform
{
    public class ProjectPlatformEditDTO
    {
        public int IdProjectPlatform { get; set; }
        public int IdPlatform { get; set; }
        public int? CohortSize { get; set; }
    }
}