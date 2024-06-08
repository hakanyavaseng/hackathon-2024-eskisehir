using HackAPI.Entities.DTOs.Products;
using HackAPI.Entities.Entities;
using HackAPI.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductsController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repositoryManager.GetReadRepository<Product>()
                .GetAllAsync();
            return Ok(products);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetProduct(int id)
        //{
        //    var product = _repositoryManager.ProductRepository.Get(id);
        //    return Ok(product);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] AddProductDto productDto)
        {
            await _repositoryManager.GetWriteRepository<Product>().AddAsync(new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                UnitCarbonFootprint = productDto.UnitCarbonFootprint
            });
            await _repositoryManager.SaveAsync();
            return Ok(productDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var product = await _repositoryManager.GetReadRepository<Product>().GetAsync(x => x.Id == Guid.Parse(id));
            if (product == null)
            {
                return NotFound();
            }
            await _repositoryManager.GetWriteRepository<Product>().DeleteAsync(product);
            await _repositoryManager.SaveAsync();
            return Ok();
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateProduct(int id, [FromBody] Product product)
        //{
        //    _repositoryManager.ProductRepository.Update(product);
        //    _repositoryManager.Save();
        //    return Ok(product);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteProduct(int id)
        //{
        //    _repositoryManager.ProductRepository.Delete(id);
        //    _repositoryManager.Save();
        //    return Ok();
        //}


    }
}
