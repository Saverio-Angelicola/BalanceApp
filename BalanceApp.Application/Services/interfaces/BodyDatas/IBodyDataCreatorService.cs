using BalanceApp.Application.Dtos.BodyData;

namespace BalanceApp.Application.Services.interfaces.BodyDatas
{
    public interface IBodyDataCreatorService
    {
        Task AddBodyData(Guid profileId, string userEmail, BodyDataDto bodyDataDto);
    }
}
