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

        [HttpPut]
        public async Task<IActionResult> UpdateTransportations([FromBody] UpdateTransportationDto transportationDto)
        {
            var transportation = await _repositoryManager.GetWriteRepository<Transportation>().UpdateAsync(new Transportation()
            {
                Id = transportationDto.Id,
                TransportationDateTime = transportationDto.TransportationDateTime.ToUniversalTime(),
                Distance = transportationDto.Distance,
                VehicleId = transportationDto.VehicleId,
                TotalCarbonFootprint = transportationDto.TotalCarbonFootprint
            });

            await _repositoryManager.SaveAsync();
           
            return Ok(transportationDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransportations(Guid id)
        {
            var transportation = await _repositoryManager.GetWriteRepository<Transportation>().DeleteAsync(id);
            await _repositoryManager.SaveAsync();
            return Ok();
        }
      


    }
}
