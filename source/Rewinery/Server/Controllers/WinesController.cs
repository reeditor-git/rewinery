﻿using Microsoft.AspNetCore.Mvc;
using Rewinery.Server.Core.Models.Wines;
using Rewinery.Server.Infrastructure;
using Rewinery.Shared.Dtos.WinesDtos;

namespace Rewinery.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinesController
    {
        private readonly WineRepository _wineRepository;

        public WinesController(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        [Route("/api/wines/{id}")]
        [HttpGet]
        public async Task<WineReadDto> GetAsync(int id)
        {
            return await _wineRepository.GetAsync(id);
        }
        [HttpGet]
        public async Task<IEnumerable<WineReadDto>> GetListAsync()
        {
            return await _wineRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<int> CreateAsync(WineCreateDto wine)
        {
            return await _wineRepository.CreateAsync(wine);
        }

        [HttpDelete]
        public async Task<int> DeleteAsync(int id)
        {
            await _wineRepository.DeleteAsync(id);
            return id;
        }
    }
}
