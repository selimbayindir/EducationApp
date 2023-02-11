using EducationApp.Domain.Entities;
using EducationAPP.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
        [HttpGet]
        public async Task GetSaveProduct()
        {
            await _productWriteRepository.AddAsync(new() { ProductName = "C Product", Price = 1.500F, CreatedDate = DateTime.UtcNow });
            await _productWriteRepository.SaveAsync();
        }

    }
}
