using HackAPI.Entities.DTOs.Productions;
using HackAPI.Entities.Entities;
using HackAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HackAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public ProductionsController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduction([FromBody] AddProductionDto productionDto)
        {
            await _repositoryManager.GetWriteRepository<ProductProductions>().AddAsync(new ProductProductions()
            {
                
            });
         
            await _repositoryManager.SaveAsync();
            return Ok(productionDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetProductions()
        {
            var productions = await _repositoryManager.GetReadRepository<Production>()
               .AsQueryable()
               .Include(x => x.ProductProductions)
               .ThenInclude(x => x.Product)
               .Select(x => new ProductionDto
               {
                   
                   Products = x.ProductProductions.Select(x => x.Product).ToList(),
                   ProductionDateTime = x.CreatedAt,
                   TotalCarbonFootprint = x.ProductProductions.Sum(x => x.Product.UnitCarbonFootprint * x.Quantity)
               })
               .ToListAsync();

               
               
            return Ok(productions);
        }

    }
}
