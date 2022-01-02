using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Business.Abstract;
using WebApiDemo.Entities;

namespace WebApiDemo.Controllers
{

    
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            
            var product= _productService.Get(id);
            if (product == null) return NotFound($" There is no product Id={id}");

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Product product)
        {
            _productService.Add(product);
            return Created("ok",product);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Product product, int id)
        {
            _productService.Update(product,id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
