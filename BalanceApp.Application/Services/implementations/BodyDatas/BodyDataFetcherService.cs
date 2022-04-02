using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.BodyDatas;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.BodyDatas
{
    public class BodyDataFetcherService : IBodyDataFetcherService
    {
        private readonly IUserRepository userRepository;

        public BodyDataFetcherService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<List<BodyData>> GetAllBodyData(string userEmail)
        {
            User user = await userRepository.FindByEmail(userEmail);
            return user.BodyDataList;
        }
    }
}