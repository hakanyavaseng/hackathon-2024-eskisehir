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
        public async Task<IActionResult> CreateProduction([FromBody] List<AddProductionDto> productionDto)
        {
            var production = new Production
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
            };

            await _repositoryManager.GetWriteRepository<Production>().AddAsync(production);
            foreach (var product in productionDto)
            {
                var productToGetUnit = await _repositoryManager.GetReadRepository<Product>().GetAsync(x => x.Id ==  product.ProductId);

                await _repositoryManager.GetWriteRepository<ProductProductions>()
                    .AddAsync(new ProductProductions
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.UtcNow,
                        ProductId = product.ProductId,
                        Quantity = product.Quantity,
                        ProductionsId = production.Id,
                        TotalCarbonFootprint = product.Quantity * productToGetUnit.UnitCarbonFootprint
                    });
            }

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
