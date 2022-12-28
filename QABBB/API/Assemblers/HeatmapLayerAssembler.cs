using QABBB.API.Models.HeatmapLayer;
using QABBB.Models;

namespace QABBB.API.Assemblers
{
    public class HeatmapLayerAssembler
    {

        public HeatmapLayerDTO toHeatmapLayerDTO(HeatmapLayer heatmapLayer) {

            HeatmapLayerDTO heatmapLayerDTO = new HeatmapLayerDTO();
            heatmapLayerDTO.IdHeatmapLayer = heatmapLayer.IdHeatmapLayer;
            heatmapLayerDTO.IdHeatmap = heatmapLayer.IdHeatmap;
            heatmapLayerDTO.ImagePath = heatmapLayer.ImagePath;
            heatmapLayerDTO.Name = heatmapLayer.Name;
            
            return heatmapLayerDTO;
        }

        public HeatmapLayer toHeatmapLayer(HeatmapLayer heatmapLayer, HeatmapLayerEditDTO heatmapLayerEditInputDTO){
            heatmapLayer.IdHeatmapLayer = heatmapLayerEditInputDTO.IdHeatmapLayer;
            heatmapLayer.IdHeatmap = heatmapLayerEditInputDTO.IdHeatmap;
            heatmapLayer.ImagePath = heatmapLayerEditInputDTO.ImagePath;
            heatmapLayer.Name = heatmapLayerEditInputDTO.Name;

            return heatmapLayer;
        }

        public List<HeatmapLayerDTO> toHeatmapLayerDTO(IEnumerable<HeatmapLayer> companies) {

            List<HeatmapLayerDTO> heatmapLayerDTO = new List<HeatmapLayerDTO>();

            foreach (HeatmapLayer heatmapLayer in companies) {
                heatmapLayerDTO.Add(toHeatmapLayerDTO(heatmapLayer));
            }

            return heatmapLayerDTO;
        }

        public HeatmapLayer toHeatmapLayer(HeatmapLayerInputDTO heatmapLayerInputDTO) {

            HeatmapLayer heatmapLayer = new HeatmapLayer();
            heatmapLayer.IdHeatmap = heatmapLayerInputDTO.IdHeatmap;
            heatmapLayer.ImagePath = heatmapLayerInputDTO.ImagePath;
            heatmapLayer.Name = heatmapLayerInputDTO.Name;

            return heatmapLayer;
        }
    }
}

