using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase {
        private readonly ProductService _service;

        public ProductController(ProductService service) {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddProduct(Product product) {
            _service.Add(product);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_service.GetAll());
        }

        [HttpPut("{id}/reduce")]
        public IActionResult ReduceStock(int id, [FromQuery] int quantity) {
            _service.ReduceStock(id, quantity);
            return Ok();
        }
    }
}
