using AccessData.Models;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace JanuaryTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _service;
        public ProductController(IProductService service) {
            _service = service;
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var product = _service.getById(id);
                return Ok(product);
            } else
            {
                return BadRequest();
            }
        }
        [HttpGet("All")]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                var products = _service.getAll();
                return Ok(products);
            } else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Add([FromBody] Product _create)
        {
            if (ModelState.IsValid)
            {
                var create = _service.Add(_create);
                return Ok(create);
            }
            else
            {
                return BadRequest();
            }
        }
        //[HttpPut]
        //public IActionResult Update(int id , [FromBody]ProductUpdateDto _create)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var update = _service.Update(id,_create);
        //        return Ok(update);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _service.Delete(id);
                return Ok(true);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
