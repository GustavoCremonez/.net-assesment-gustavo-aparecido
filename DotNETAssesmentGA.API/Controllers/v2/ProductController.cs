using DotNETAssesmentGA.Application.DTOs;
using DotNETAssesmentGA.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNETAssesmentGA.API.Controllers.v2
{
    [ApiController]
    [Route("api/{version:apiVersion}/product")]
    [ApiVersion("2.0")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceMongo _mongoService;

        public ProductController(IProductServiceMongo mongoService)
        {
            _mongoService = mongoService;
        }

        [MapToApiVersion("2.0")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<ProductDTO> products = await _mongoService.GetAllAsync();

                if (products.Count() > 0) return Ok(products);
                else return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("2.0")]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                ProductDTO products = await _mongoService.GetByIdAsync(id);

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<IActionResult> Add(ProductDTO dto)
        {
            try
            {
                return Ok(await _mongoService.AddAsync(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("2.0")]
        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO dto)
        {
            try
            {
                return Ok(await _mongoService.UpdateAsync(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("2.0")]
        [HttpDelete]
        public async Task<IActionResult> remove(string id)
        {
            try
            {
                await _mongoService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}