using BalanceApp.Application.Repositories;

namespace BalanceApp.Application.Datas
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
