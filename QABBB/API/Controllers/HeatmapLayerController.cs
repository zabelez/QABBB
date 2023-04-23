using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.API.Assemblers;
using QABBB.API.Models.HeatmapLayer;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class HeatmapLayerController : ControllerBase
    {
        private readonly QABBBContext _context;
        private readonly HeatmapLayerServices _heatmapLayerServices;
        private readonly HeatmapLayerAssembler _heatmapLayerAssembler;

        public HeatmapLayerController(QABBBContext context)
        {
            _context = context;
            _heatmapLayerServices = new HeatmapLayerServices(_context);
            _heatmapLayerAssembler = new HeatmapLayerAssembler();
        }

        // GET: api/HeatmapLayer
        [HttpGet]
        public ActionResult<List<HeatmapLayerDTO>> GetHeatmapLayers()
        {
            if (_context.HeatmapLayers == null)
                return NotFound();

            List<HeatmapLayer> heatmapLayers = _heatmapLayerServices.list();

            List<HeatmapLayerDTO> heatmapLayerDTOs = _heatmapLayerAssembler.toHeatmapLayerDTO(heatmapLayers);
          
            return Ok(heatmapLayerDTOs);
        }

        // GET: api/HeatmapLayer/5
        [HttpGet("{id}")]
        public ActionResult<HeatmapLayerDTO> GetHeatmapLayer(int id)
        {
            if (_context.HeatmapLayers == null)
                return NotFound();
          
            HeatmapLayer? heatmapLayer = _heatmapLayerServices.findById(id);
            if(heatmapLayer == null)
                return NotFound();

            HeatmapLayerDTO heatmapLayerDTO = _heatmapLayerAssembler.toHeatmapLayerDTO(heatmapLayer);

            return Ok(heatmapLayerDTO);
        }

        // PUT: api/HeatmapLayer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        public ActionResult PutHeatmapLayer(HeatmapLayerEditDTO heatmapLayerEditDTO)
        {
            HeatmapLayer? heatmapLayer = _heatmapLayerServices.findById(heatmapLayerEditDTO.IdHeatmapLayer);
            if(heatmapLayer == null)
                return NotFound();

            _heatmapLayerAssembler.toHeatmapLayer(heatmapLayer, heatmapLayerEditDTO);
            
            _heatmapLayerServices.edit(heatmapLayer);
            
            return NoContent();
        }

        // POST: api/HeatmapLayer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<HeatmapLayerDTO> PostHeatmapLayer(HeatmapLayerInputDTO heatmapLayerInputDTO)
        {
            if (_context.HeatmapLayers == null)
                return Problem("Entity set 'QABBBContext.HeatmapLayers'  is null.");

            HeatmapLayer heatmapLayer = _heatmapLayerAssembler.toHeatmapLayer(heatmapLayerInputDTO);

            _heatmapLayerServices.add(heatmapLayer);

            HeatmapLayerDTO heatmapLayerDTO = _heatmapLayerAssembler.toHeatmapLayerDTO(heatmapLayer);

            return CreatedAtAction("GetHeatmapLayer", new { id = heatmapLayerDTO.IdHeatmapLayer }, heatmapLayerDTO);
        }

        // DELETE: api/HeatmapLayer/5
        [HttpDelete("{id}")]
        public ActionResult DeleteHeatmapLayer(int id)
        {
            if (_context.HeatmapLayers == null)
                return NotFound();
            
            HeatmapLayer? heatmapLayer = _heatmapLayerServices.findById(id);
            if(heatmapLayer == null)
                return NotFound();

            _heatmapLayerServices.delete(heatmapLayer);

            return NoContent();
        }
    }
}
