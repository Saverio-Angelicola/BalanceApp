using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Application.Providers;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.BodyDatas;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.BodyDatas
{
    public class BodyDataFetcherService : IBodyDataFetcherService
    {
        private readonly IUserRepository userRepository;
        private readonly IWithingsProvider withingsProvider;

        public BodyDataFetcherService(IUserRepository userRepository, IWithingsProvider withingsProvider)
        {
            this.userRepository = userRepository;
            this.withingsProvider = withingsProvider;
        }

        public async Task<BodyDataListDto> GetAllBodyData(string userEmail, string withingsToken)
        {
            try
            {
                User user = await userRepository.FindByEmail(userEmail);

                List<BodyData> recentMeasures = await withingsProvider.GetMeasures(withingsToken, user.LastUpdate,user.Height);

                if(recentMeasures.Count > 0)
                {
                    foreach (BodyData measure in recentMeasures)
                    {
                        user.BodyDataList.Add(measure);
                    }
                    long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                    user.LastUpdate = timestamp.ToString();
                    await userRepository.Update(user);
                }
                
                return new BodyDataListDto(user.BodyDataList);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BodyDataListDto> GetBodyDataById(Guid id)
        {
            try
            {
                User user = await userRepository.FindById(id);

                return new BodyDataListDto(user.BodyDataList);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}