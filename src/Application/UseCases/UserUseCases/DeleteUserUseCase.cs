

using Application.Abstractions.UserUseCases;
using Application.Exceptions.UserExceptions;
using Domain.Interfaces;

namespace Application.UseCases.UserUseCases
{
    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException("User does not exist.");
            }

            await _userRepository.DeleteUserAsync(user);
        }
    }
}
