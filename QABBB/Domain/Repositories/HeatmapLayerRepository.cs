using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class HeatmapLayerRepository
    {
        private readonly QABBBContext _context;

        public HeatmapLayerRepository(QABBBContext context) {
            _context = context;
        }

        public List<HeatmapLayer> list(){
            return _context.HeatmapLayers.ToList();
        }

        public bool add(HeatmapLayer heatmapLayer) {
            _context.HeatmapLayers.Add(heatmapLayer);
            _context.SaveChanges();
            return true;
        }

        public bool save(HeatmapLayer heatmapLayer){
            _context.Entry(heatmapLayer).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public HeatmapLayer? findById(int id) {
            return _context.HeatmapLayers.FirstOrDefault();
        }

        public bool edit(HeatmapLayer heatmapLayer){
            _context.Entry(heatmapLayer).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(HeatmapLayer heatmapLayer){
            _context.HeatmapLayers.Remove(heatmapLayer);
            _context.SaveChanges();
            return true;
        }
    }
}

