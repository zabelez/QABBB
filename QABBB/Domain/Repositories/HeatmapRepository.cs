using System;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.Domain.Repositories
{
    public class HeatmapRepository
    {
        private readonly QABBBContext _context;

        public HeatmapRepository(QABBBContext context) {
            _context = context;
        }

        public List<Heatmap> list(){
            return _context.Heatmaps.ToList();
        }

        public bool add(Heatmap heatmap) {
            _context.Heatmaps.Add(heatmap);
            _context.SaveChanges();
            return true;
        }

        public bool save(Heatmap heatmap){
            _context.Entry(heatmap).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public Heatmap? findById(int id) {
            return _context.Heatmaps.FirstOrDefault();
        }

        public bool edit(Heatmap heatmap){
            _context.Entry(heatmap).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool delete(Heatmap heatmap){
            _context.Heatmaps.Remove(heatmap);
            _context.SaveChanges();
            return true;
        }
    }
}

