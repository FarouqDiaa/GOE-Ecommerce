namespace Application.Abstractions.UserUseCases
{
    public interface IDeleteUserUseCase
    {
        Task ExecuteAsync(Guid userId);
    }
}
