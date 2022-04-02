using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.BodyDatas;
using BalanceApp.Application.Services.Providers;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.BodyDatas
{
    public class BodyDataCreatorService : IBodyDataCreatorService
    {
        private readonly IUserRepository userRepository;
        private readonly IDateTimeProvider dateTimeProvider;

        public BodyDataCreatorService(IUserRepository userRepository, IDateTimeProvider dateTimeProvider)
        {
            this.userRepository = userRepository;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task AddBodyData(string userEmail, BodyDataDto bodyDataDto)
        {
            try
            {
                User user = await userRepository.FindByEmail(userEmail);
                BodyData bodyData = new(bodyDataDto.Weight, bodyDataDto.Height, bodyDataDto.FatMassRate, bodyDataDto.WaterRate, bodyDataDto.MuscleRate, bodyDataDto.BoneRate, bodyDataDto.HeartBeat, bodyDataDto.BodyMassIndex, dateTimeProvider.GetUtcNow());
                user.AddBodyData(bodyData);
            }
            catch(Exception)
            {
                throw new AddingBodyDataException();
            }
            
        }
    }
}
