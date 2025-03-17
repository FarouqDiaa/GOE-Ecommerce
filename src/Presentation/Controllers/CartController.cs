using Microsoft.AspNetCore.Mvc;
using Application.Abstractions.Services;
using AutoMapper;
using Presentation.ViewModels.ProductViewModels;
using Application.DTOs.ProductDTOs;
using Application.Responses;
using Application.DTOs.CartDTOs;
using Presentation.ViewModels.CartViewModels;

namespace Presentation.Controllers
{
    [Route("api/cart/{userId}")]
    public class CartController : Controller
    {
        private readonly ICartManagmentService _cartManagementService;
        private readonly IMapper _mapper;

        public CartController(ICartManagmentService cartManagementService, IMapper mapper)
        {
            _cartManagementService = cartManagementService;
            _mapper = mapper;
        }

        [HttpPost("{userId}/items")]
        public async Task <IActionResult> AddProductToCart(Guid userId, [FromBody] ProductViewModel viewModel)
        {
            var dto = _mapper.Map<ProductDTO>(viewModel);
            await _cartManagementService.AddProductToCartAsync(dto, userId);
            return Created(string.Empty, new SuccessResponse<string>("Product added successfully."));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartDetails(Guid userId)
        {
            var cartDTO = await _cartManagementService.GetCartDetailsAsync(userId);
            var cartViewModel = _mapper.Map<CartDTO, CartViewModel>(cartDTO);
            return Ok(new SuccessResponse<CartViewModel>(cartViewModel));
        }

        [HttpDelete("{userId}/items/{productId}")]
        public async Task<IActionResult> RemoveProductFromCart(Guid userId, Guid productId)
        {
            await _cartManagementService.RemoveProductFromCartAsync(userId, productId);
            return NoContent();
        }
    }
}
