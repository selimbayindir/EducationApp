using EducationApp.Domain.Entities;
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
        public async void Get() 
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(),ProductName="Product 1",Price=100,CreatedDate=DateTime.UtcNow,Stock=10 },
                new(){Id=Guid.NewGuid(),ProductName="Product 2",Price=200,CreatedDate=DateTime.UtcNow,Stock=20 },
                new(){Id=Guid.NewGuid(),ProductName="Product 2",Price=300,CreatedDate=DateTime.UtcNow,Stock=130 }
                });
            await _productWriteRepository.SaveAsync();
        }

    }
}
