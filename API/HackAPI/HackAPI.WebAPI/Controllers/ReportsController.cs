using HackAPI.Entities.DTOs.Productions;
using HackAPI.Entities.Entities;
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
                .GroupBy(x => x.Product.CreatedAt.Month) // Group by month number
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
                .GroupBy(x => x.Product.CreatedAt.Year) // Group by year
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
                .GroupBy(x => x.CreatedAt.Month) // Group by month number
                .Select(x => new
                {
                    MonthNumber = x.Key,
                    MonthName = CultureInfo.GetCultureInfo("EN-en").DateTimeFormat.GetMonthName(x.Key),
                    TotalCarbonFootprintCount = x.Sum(p => p.TotalCarbonFootprint)
                })
                .OrderBy(p => p.MonthNumber)
                .ToListAsync();

            return Ok(transportations);
        }

        [HttpGet("GetTransportationsWithCarbonFootprintByYear")]
        public async Task<IActionResult> GetTransportationsWithCarbonFootprintByYear()
        {
            var transportations = await _repositoryManager.GetReadRepository<Transportation>()
                .AsQueryable()
                .GroupBy(x => x.CreatedAt.Year) // Group by year
                .Select(x => new
                {
                    Year = x.Key,
                    TotalCarbonFootprintCount = x.Sum(p => p.TotalCarbonFootprint)
                })
                .OrderBy(p => p.Year)
                .ToListAsync();

            return Ok(transportations);
        }

       

    }
}

