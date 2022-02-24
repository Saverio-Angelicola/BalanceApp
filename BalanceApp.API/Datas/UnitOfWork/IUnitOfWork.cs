using BalanceApp.API.Repositories.interfaces;

namespace BalanceApp.API.Datas.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
