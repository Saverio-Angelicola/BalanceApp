using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.interfaces.BodyDatas
{
    public interface IBodyDataFetcherService
    {
        Task<BodyDataListDto> GetAllBodyData(string userEmail, string withingsToken);
        Task<BodyDataListDto> GetBodyDataById(Guid id);
    }
}
