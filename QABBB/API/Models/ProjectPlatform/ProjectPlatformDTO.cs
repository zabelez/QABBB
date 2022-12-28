using System;
using QABBB.API.Models.Heatmap;

namespace QABBB.API.Models.ProjectPlatform
{
    public class ProjectPlatformDTO
    {
        public int IdProjectPlatform {get; set;}
        public int IdPlatform { get; set; }
        public string? Name { get; set; }
        public int? Cohortsize {get; set; }
        public HeatmapDTO? Heatmap {get; set;}
    }
}