using BalanceApp.Application.Dtos.BodyData;

namespace BalanceApp.Application.Services.interfaces.BodyDatas
{
    public interface IBodyDataCreatorService
    {
        Task AddBodyData(string userEmail, BodyDataDto bodyDataDto);
    }
}
