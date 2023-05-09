using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QABBB.API.Assemblers;
using QABBB.API.Models.Heatmap;
using QABBB.Data;
using QABBB.Domain.Services;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    // [Authorize(Roles = "Admin")]
    // public class HeatmapController : ControllerBase
    // {
    //     private readonly QABBBContext _context;
    //     private readonly HeatmapServices _heatmapServices;
    //     private readonly HeatmapAssembler _heatmapAssembler;

    //     public HeatmapController(QABBBContext context)
    //     {
    //         _context = context;
    //         _heatmapServices = new HeatmapServices(_context);
    //         _heatmapAssembler = new HeatmapAssembler();
    //     }

    //     // GET: api/Heatmap
    //     [HttpGet]
    //     public ActionResult<List<HeatmapDTO>> GetHeatmaps()
    //     {
    //         if (_context.Heatmaps == null)
    //             return NotFound();

    //         List<Heatmap> heatmaps = _heatmapServices.list();

    //         List<HeatmapDTO> heatmapDTOs = _heatmapAssembler.toHeatmapDTO(heatmaps);
          
    //         return Ok(heatmapDTOs);
    //     }

    //     // GET: api/Heatmap/5
    //     [HttpGet("{id}")]
    //     public ActionResult<HeatmapDTO> GetHeatmap(int id)
    //     {
    //         if (_context.Heatmaps == null)
    //             return NotFound();
          
    //         Heatmap? heatmap = _heatmapServices.findById(id);
    //         if(heatmap == null)
    //             return NotFound();

    //         HeatmapDTO heatmapDTO = _heatmapAssembler.toHeatmapDTO(heatmap);

    //         return Ok(heatmapDTO);
    //     }

    //     // PUT: api/Heatmap/5
    //     // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //     [HttpPut()]
    //     public ActionResult PutHeatmap(HeatmapEditDTO heatmapEditDTO)
    //     {
    //         Heatmap? heatmap = _heatmapServices.findById(heatmapEditDTO.IdHeatmap);
    //         if(heatmap == null)
    //             return NotFound();

    //         _heatmapAssembler.toHeatmap(heatmap, heatmapEditDTO);
            
    //         _heatmapServices.edit(heatmap);
            
    //         return NoContent();
    //     }

    //     // POST: api/Heatmap
    //     // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //     [HttpPost]
    //     public ActionResult<HeatmapDTO> PostHeatmap(HeatmapInputDTO heatmapInputDTO)
    //     {
    //         if (_context.Heatmaps == null)
    //             return Problem("Entity set 'QABBBContext.Heatmaps'  is null.");

    //         Heatmap heatmap = _heatmapAssembler.toHeatmap(heatmapInputDTO);

    //         _heatmapServices.add(heatmap);

    //         HeatmapDTO heatmapDTO = _heatmapAssembler.toHeatmapDTO(heatmap);

    //         return CreatedAtAction("GetHeatmap", new { id = heatmapDTO.IdHeatmap }, heatmapDTO);
    //     }

    //     // DELETE: api/Heatmap/5
    //     [HttpDelete("{id}")]
    //     public ActionResult DeleteHeatmap(int id)
    //     {
    //         if (_context.Heatmaps == null)
    //             return NotFound();
            
    //         Heatmap? heatmap = _heatmapServices.findById(id);
    //         if(heatmap == null)
    //             return NotFound();

    //         _heatmapServices.delete(heatmap);

    //         return NoContent();
    //     }
    // }
}
