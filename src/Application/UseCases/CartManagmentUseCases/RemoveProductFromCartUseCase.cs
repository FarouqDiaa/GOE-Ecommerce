using Application.Abstractions.CartManagmentUseCases;
using Application.Exceptions.CartExceptions;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.CartManagmentUseCases
{
    public class RemoveProductFromCartUseCase : IRemoveProductFromCartUseCase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public RemoveProductFromCartUseCase(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(Guid userId, Guid productId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                throw new CartNotFoundException("Cart not found");
            }

            var cartItem = cart.CartItems.FirstOrDefault(p => p.ProductId == productId);
            if (cartItem == null)
            {
                throw new Exception("Product not found in cart");
            }

            cart.CartItems.Remove(cartItem); 
            await _cartRepository.RemoveCartItemAsync(cartItem);
            await _cartRepository.UpdateCartAsync(cart);
        }
    }
}
