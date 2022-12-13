using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QABBB.API.Assemblers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using QABBB.Models;
using QABBB.Data;
using QABBB.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace QABBB.Domain.Services
{
    public class HeatMapServices
    {
        private readonly QABBBContext _context;
        private readonly HeatmapRepository _heatmapRepository;

        public HeatMapServices(QABBBContext context) {
            _context = context;
            _heatmapRepository = new HeatmapRepository(_context);
        }

        public List<Heatmap> list() {
            return _heatmapRepository.list();
        }

        public Heatmap? findById(int id) {
            return _heatmapRepository.findById(id);
        }

        public bool add(Heatmap heatmap) {
            return _heatmapRepository.add(heatmap) ? true : false;
        }

        public bool edit(Heatmap heatmap){
            return _heatmapRepository.edit(heatmap);
        }

        public bool delete(Heatmap heatmap){
            return _heatmapRepository.delete(heatmap);
        }
    }
}

