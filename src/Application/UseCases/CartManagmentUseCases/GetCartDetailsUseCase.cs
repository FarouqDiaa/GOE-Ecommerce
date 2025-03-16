

using Application.Abstractions.CartManagmentUseCases;
using Application.DTOs.CartDTOs;
using AutoMapper;
using Domain.Interfaces;

namespace Application.UseCases.CartManagmentUseCases
{
    public class GetCartDetailsUseCase : IGetCartDetailsUseCase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartDetailsUseCase(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CartDTO> ExecuteAsync(Guid userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                throw new KeyNotFoundException("Cart not found for the given user ID.");
            }
            return _mapper.Map<CartDTO>(cart);
        }
    }
}
