using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet("AddList")]
        public async Task<IActionResult> AddRange()
        {
            await _productWriteRepository.AddRangeAsync(new List<Product>()
            {
                new ( ) { Id = Guid.NewGuid() , Name = " Product 1 " , Price = 100 , CreatedDate = DateTime.UtcNow , Stock = 10 } ,
                new ( ) { Id = Guid.NewGuid() , Name = " Product 2 " , Price = 200 , CreatedDate = DateTime . UtcNow , Stock = 20 } ,
                new ( ) { Id = Guid.NewGuid() , Name = " Product 3 " , Price = 300 , CreatedDate = DateTime.UtcNow , Stock = 138 } ,
            });
            var count = _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result =await _productReadRepository.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
