using HackAPI.Entities.DTOs.Transportations;
using HackAPI.Entities.DTOs.Vehicles;
using HackAPI.Entities.Entities;
using HackAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportationsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public TransportationsController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetTransportations()
        {
            var transportations = await _repositoryManager.GetReadRepository<Transportation>()
               .AsQueryable()
               .Include(x => x.Vehicle)
               .ToListAsync();
            return Ok(transportations);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransportations([FromBody] AddTransportationDto transportationDto)
        {
            await _repositoryManager.GetWriteRepository<Transportation>().AddAsync(new Transportation()
            {
                TransportationDateTime = transportationDto.TransportationDateTime.ToUniversalTime(),
                Distance = transportationDto.Distance,
                VehicleId = transportationDto.VehicleId,
                TotalCarbonFootprint = transportationDto.TotalCarbonFootprint

            });
            await _repositoryManager.SaveAsync();
            return Ok(transportationDto);
        }
      


    }
}
