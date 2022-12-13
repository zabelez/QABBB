using QABBB.API.Models.Project.Heatmap;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class HeatmapAssembler
    {

        public HeatmapDTO toHeatmapDTO(Heatmap heatmap) {

            HeatmapDTO heatmapDTO = new HeatmapDTO();
            heatmapDTO.IdHeatmap = heatmap.IdHeatmap;
            heatmapDTO.IdProject = heatmap.IdProject;
            heatmapDTO.Color = heatmap.Color;
            
            return heatmapDTO;
        }

        public Heatmap toHeatmap(Heatmap heatmap, HeatmapEditDTO heatmapEditInputDTO){
            heatmap.IdHeatmap = heatmapEditInputDTO.IdHeatmap;
            heatmap.IdProject = heatmapEditInputDTO.IdProject;
            heatmap.Color = heatmapEditInputDTO.Color;

            return heatmap;
        }

        public List<HeatmapDTO> toHeatmapDTO(IEnumerable<Heatmap> companies) {

            List<HeatmapDTO> heatmapDTO = new List<HeatmapDTO>();

            foreach (Heatmap heatmap in companies) {
                heatmapDTO.Add(toHeatmapDTO(heatmap));
            }

            return heatmapDTO;
        }

        public Heatmap toHeatmap(HeatmapInputDTO heatmapInputDTO) {

            Heatmap heatmap = new Heatmap();
            heatmapInputDTO.IdProject = heatmap.IdProject;
            heatmapInputDTO.Color = heatmap.Color;

            return heatmap;
        }
    }
}

