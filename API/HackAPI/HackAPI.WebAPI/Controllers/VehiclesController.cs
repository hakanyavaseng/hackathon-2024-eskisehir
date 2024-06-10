using HackAPI.Entities.DTOs.Products;
using HackAPI.Entities.DTOs.Vehicles;
using HackAPI.Entities.Entities;
using HackAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public VehiclesController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _repositoryManager.GetReadRepository<Vehicle>()
                .GetAllAsync();
            return Ok(vehicles);
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] AddVehicleDto vehicleDto)
        {
            await _repositoryManager.GetWriteRepository<Vehicle>().AddAsync(new Vehicle()
            {
                VehicleName = vehicleDto.VehicleName,
                VehicleType = vehicleDto.VehicleType,
                VehicleModel = vehicleDto.VehicleModel,
                UnitCarbonFootprint = vehicleDto.UnitCarbonFootprint

            });
            await _repositoryManager.SaveAsync();
            return Ok(vehicleDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            var vehicle = await _repositoryManager.GetReadRepository<Vehicle>().GetAsync(x => x.Id == Guid.Parse(id));
            if (vehicle == null)
            {
                return NotFound();
            }
                await _repositoryManager.GetWriteRepository<Vehicle>().DeleteAsync(vehicle);
            await _repositoryManager.SaveAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVehicle([FromBody] UpdateVehicleDto vehicleDto)
        {
            var vehicle = await _repositoryManager.GetWriteRepository<Vehicle>().UpdateAsync(new Vehicle()
            {
                Id = vehicleDto.Id,
                VehicleName = vehicleDto.VehicleName,
                VehicleType = vehicleDto.VehicleType,
                VehicleModel = vehicleDto.VehicleModel,
                UnitCarbonFootprint = vehicleDto.UnitCarbonFootprint
            });
            await _repositoryManager.SaveAsync();

            return Ok(vehicleDto);
        }



    } 
}
