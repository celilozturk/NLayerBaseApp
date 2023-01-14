using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    //[Route("api/[controller]/[action]")]  // => Action'da olur ise, metoda istek yaparken metod_adini da yazmak gerekir.
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        //Generic Respositorylerde Mapping Controller tarafinda olur. Ancak CustomRepositorylerde Service katmaninda gerceklestirilir.
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductsController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }
        //Get api/products
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productsDto));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }
        // GET /api/products/5/6
        //[HttpGet("{id}/{xId}")]
        // GET /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productsDto));
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }
        [HttpPost()]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            //  return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productsDto));
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }
        [HttpPut()]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
           
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        //DELETE api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);         
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
