namespace Application.Abstractions.UserUseCases
{
    public interface IDeleteUserUseCase
    {
        Task Execute(Guid userId);
    }
}
