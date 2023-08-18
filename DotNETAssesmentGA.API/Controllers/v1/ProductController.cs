using DotNETAssesmentGA.Application.DTOs;
using DotNETAssesmentGA.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNETAssesmentGA.API.Controllers.v1
{
    [ApiController]
    [Route("api/{version:apiVersion}/product")]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceSQL _sqlService;

        public ProductController(IProductServiceSQL sqlService)
        {
            _sqlService = sqlService;
        }

        [MapToApiVersion("1.0")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<ProductDTO> products = await _sqlService.GetAllAsync();

                if (products.Count() > 0) return Ok(products);
                else return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ProductDTO products = await _sqlService.GetByIdAsync(id);

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> Add(ProductDTO dto)
        {
            try
            {
                return Ok(await _sqlService.AddAsync(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPut]
        public async Task<IActionResult> Update(ProductDTO dto)
        {
            try
            {
                return Ok(await _sqlService.UpdateAsync(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpDelete]
        public async Task<IActionResult> remove(int id)
        {
            try
            {
                await _sqlService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}