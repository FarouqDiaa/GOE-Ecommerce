using Application.Abstractions.Services;
using Application.DTOs.ProductTranslationDTOs;
using Application.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.ProductTranslation;

namespace Presentation.Controllers
{
    [Route("api/products/{productId}/translations")]
    [ApiController]
    public class ProductTranslationController : Controller
    {
        private readonly IProductTranslationService _productTranslationService;
        private readonly IMapper _mapper;

        public ProductTranslationController(IProductTranslationService productTranslationService, IMapper mapper)
        {
            _productTranslationService = productTranslationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddTranslation(Guid productId, [FromBody] ProductTranslationViewModel viewModel)
        {

            var dto = _mapper.Map<NewProductTranslationDTO>(viewModel);
            dto.ProductId = productId;
            await _productTranslationService.AddTranslationAsync(dto);

            return Created(string.Empty, new SuccessResponse<string>("Translation Added Successfully"));
        }

        [HttpGet("{productId}/{language}")]
        public async Task<IActionResult> GetTranslation(Guid productId, string language)
        {
            var productTranslationDto = await _productTranslationService.GetProductTranslationAsync(productId, language);

            var productTranslationViewModel = _mapper.Map<ProductTranslationViewModel>(productTranslationDto);
            return Ok(new SuccessResponse<ProductTranslationViewModel> (productTranslationViewModel));

        }
    }
}
