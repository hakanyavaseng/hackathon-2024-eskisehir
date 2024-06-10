using HackAPI.Entities.DTOs.Analysis;
using HackAPI.Entities.DTOs.Productions;
using HackAPI.Entities.Entities;
using HackAPI.Entities.Enums;
using HackAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace HackAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public ReportsController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }

        [HttpGet("GetProductionsWithCarbonFootprintByMonth")]
        public async Task<IActionResult> GetProductionsWithCarbonFootprintByMonth()
        {
            var productions = await _repositoryManager.GetReadRepository<ProductProductions>()
                .AsQueryable()
                .Include(x => x.Product)
                .GroupBy(x => x.Productions.CreatedAt.Month) // Group by month number
                .Select(x => new
                {
                    MonthNumber = x.Key,
                    MonthName = CultureInfo.GetCultureInfo("EN-en").DateTimeFormat.GetMonthName(x.Key),
                    TotalCarbonFootprintCount = x.Sum(p => p.TotalCarbonFootprint)
                })
                .OrderBy(p => p.MonthNumber)
                .ToListAsync();

            return Ok(productions);
        }

        [HttpGet("GetProductionsWithCarbonFootprintByYear")]
        public async Task<IActionResult> GetProductionsWithCarbonFootprintByYear()
        {
            var productions = await _repositoryManager.GetReadRepository<ProductProductions>()
                .AsQueryable()
                .Include(x => x.Product)
                .GroupBy(x => x.Productions.CreatedAt.Year) // Group by year
                .Select(x => new
                {
                    Year = x.Key,
                    TotalCarbonFootprintCount = x.Sum(p => p.TotalCarbonFootprint)
                })
                .OrderBy(p => p.Year)
                .ToListAsync();

            return Ok(productions);
        }

        [HttpGet("GetTransportationsWithCarbonFootprintByMonth")]
        public async Task<IActionResult> GetTransportationsWithCarbonFootprintByMonth()
        {
            var transportations = await _repositoryManager.GetReadRepository<Transportation>()
                .AsQueryable()
                .GroupBy(x => x.TransportationDateTime.Month) // Group by month number
                .Select(x => new ByMonthModel()
                {
                    MonthNumber = x.Key,
                    MonthName = CultureInfo.GetCultureInfo("EN-en").DateTimeFormat.GetMonthName(x.Key),
                    TotalCarbonFootprintCount = (double)x.Sum(p => p.TotalCarbonFootprint)
                })
                .OrderBy(p => p.MonthNumber)
                .ToListAsync();

   

            var totalCarbonFootprintIfElectrical = await _repositoryManager.GetReadRepository<Transportation>()
                .AsQueryable()
                .GroupBy(x => x.TransportationDateTime.Month) // Group by month number
                .Where(p => p.Where(x => x.Vehicle.VehicleType == VehicleType.FossilFuel.ToString()).Count() > 0)
                .Select(x => new ByMonthModel()
                {
                    MonthNumber = x.Key,
                    MonthName = CultureInfo.GetCultureInfo("EN-en").DateTimeFormat.GetMonthName(x.Key),
                    TotalCarbonFootprintCount = (double)x.Sum(p => p.TotalCarbonFootprint) * 0.4646
                })
                .OrderBy(p => p.MonthNumber)
                .ToListAsync();

            
            return Ok(new TransportationsByMonth()
            {
                 Transportation = transportations,
                 TotalCarbonFootprintIfElectrical = totalCarbonFootprintIfElectrical
                
            });
        }

        [HttpGet("GetTransportationsWithCarbonFootprintByYear")]
        public async Task<IActionResult> GetTransportationsWithCarbonFootprintByYear()
        {
            var transportations = await _repositoryManager.GetReadRepository<Transportation>()
                .AsQueryable()
                .GroupBy(x => x.TransportationDateTime.Year) // Group by year
                .Select(x => new ByYearModel()
                {
                    Year = x.Key,
                    TotalCarbonFootprintCount = (double)x.Sum(p => p.TotalCarbonFootprint)
                })
                .OrderBy(p => p.Year)
                .ToListAsync();

            var totalCarbonFootprintIfElectrical = await _repositoryManager.GetReadRepository<Transportation>()
                .AsQueryable()
                .GroupBy(x => x.TransportationDateTime.Year) // Group by year
                .Where(p => p.Where(x => x.Vehicle.VehicleType == VehicleType.FossilFuel.ToString()).Count() > 0)
                .Select(x => new ByYearModel()
                { 
                    Year = x.Key,
                    TotalCarbonFootprintCount = (double)x.Sum(p => p.TotalCarbonFootprint) * 0.4646
                })
                .OrderBy(p => p.Year)
                .ToListAsync();

            return Ok(new TransportationByYear()
            {
                Transportation = transportations,
                TotalCarbonFootprintIfElectrical = totalCarbonFootprintIfElectrical
            });
        }

        [HttpGet("GetSavedCarbonEmission")]
        public async Task<IActionResult> GetSavedCarbonEmission()
        {
            var transportations = await _repositoryManager.GetReadRepository<Transportation>()
                .AsQueryable()
                .Include(x => x.Vehicle)
                .ToListAsync();
            var savedCarbonEmission = 0.0;
            var fossilFuelTransportations = transportations.Where(x => x.Vehicle.VehicleType == VehicleType.FossilFuel.ToString()).Count();
            foreach (var transportation in transportations)
            {
                if (transportation.Vehicle.VehicleType == VehicleType.FossilFuel.ToString())
                {
                    savedCarbonEmission = savedCarbonEmission + ((double)transportation.Distance * 0.4646);
                }
            }
            return Ok(new SavedCarbonEmmisionModel()
            {
                FossilFuelVehicleCount = fossilFuelTransportations,
                SavedCarbonEmmision = savedCarbonEmission
            });
        }




    }
}

