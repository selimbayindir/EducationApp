using EducationApp.Domain.Entities;
using EducationApp.Persistence.Concrete.Repositories;
using EducationAPP.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InMemoryProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public InMemoryProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet("InMemorySaveProduct")]
        public async /*void*/Task Get()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(),ProductName="Product 1",Price=100,CreatedDate=DateTime.UtcNow,Stock=10 },
                new(){Id=Guid.NewGuid(),ProductName="Product 2",Price=200,CreatedDate=DateTime.UtcNow,Stock=20 },
                new(){Id=Guid.NewGuid(),ProductName="Product 2",Price=300,CreatedDate=DateTime.UtcNow,Stock=130 }
                });
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAllProduct()
        {
            var product = _productReadRepository.GetAll();
            return Ok(product);
        }
        [HttpGet("{ProductName}")]
        public async Task<IActionResult> gET(string ProductName)
        {
            var product = _productReadRepository.GetWhere(x => x.ProductName == ProductName);
            return Ok(product);
        }

    }
}
