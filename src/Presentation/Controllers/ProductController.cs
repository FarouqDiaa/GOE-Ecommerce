using Application.Abstractions.Services;
using Application.DTOs.ProductDTOs;
using Application.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.ProductViewModels;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] NewProductViewModel newProductViewModel)
        {
            var newProductDTO = _mapper.Map<NewProductViewModel, NewProductDTO>(newProductViewModel);
            await _productService.AddProductAsync(newProductDTO);
            return Created(string.Empty, new SuccessResponse<string>("Product added successfully."));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.ListProductsAsync();
            var productViewModels = _mapper.Map<IEnumerable<ProductDTO>, IEnumerable<ProductViewModel>>(products);
            return Ok(new SuccessResponse<IEnumerable<ProductViewModel>>(productViewModels));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetProductDetailsAsync(id);
            var productViewModel = _mapper.Map<ProductDTO, ProductViewModel>(product);
            return Ok(new SuccessResponse<ProductViewModel>(productViewModel));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] NewProductViewModel productViewModel)
        {
            var productDTO = _mapper.Map<NewProductViewModel, NewProductDTO>(productViewModel);
            await _productService.UpdateProductAsync(id, productDTO);
            return Ok(new SuccessResponse<string>("Product Updated Successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.RemoveProductsAsync(id);
            return NoContent();
        }
    }
}
