using Application.Abstractions.CartManagmentUseCases;
using Application.DTOs.ProductDTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CartManagmentUseCases
{
    public class AddProductToCartUseCase : IAddProductToCartUseCase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public AddProductToCartUseCase(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(ProductDTO productDTO, Guid userId)
        {
            var product = _mapper.Map<Product>(productDTO);
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId, CartItems = new List<CartItem>() };
                await _cartRepository.CreateCartAsync(cart);
            }

            var cartItem = new CartItem
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = productDTO.Quantity
            };

            await _cartRepository.AddCartItemAsync(cartItem);
            cart.CartItems.Add(cartItem);
            await _cartRepository.UpdateCartAsync(cart);
        }
    }
}
