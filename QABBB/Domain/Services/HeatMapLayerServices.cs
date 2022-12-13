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
    public class HeatMapLayerServices
    {
        private readonly QABBBContext _context;
        private readonly HeatmapLayerRepository _heatmapLayerRepository;

        public HeatMapLayerServices(QABBBContext context) {
            _context = context;
            _heatmapLayerRepository = new HeatmapLayerRepository(_context);
        }

        public List<HeatmapLayer> list() {
            return _heatmapLayerRepository.list();
        }

        public HeatmapLayer? findById(int id) {
            return _heatmapLayerRepository.findById(id);
        }

        public bool add(HeatmapLayer heatmapLayer) {
            return _heatmapLayerRepository.add(heatmapLayer) ? true : false;
        }

        public bool edit(HeatmapLayer heatmapLayer){
            return _heatmapLayerRepository.edit(heatmapLayer);
        }

        public bool delete(HeatmapLayer heatmapLayer){
            return _heatmapLayerRepository.delete(heatmapLayer);
        }
    }
}

