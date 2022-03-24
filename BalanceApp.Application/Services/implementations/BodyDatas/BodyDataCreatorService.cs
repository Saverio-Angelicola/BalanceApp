using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Application.Services.interfaces.BodyDatas;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.BodyDatas
{
    public class BodyDataCreatorService : IBodyDataCreatorService
    {
        private readonly IUserRepository userRepository;

        public BodyDataCreatorService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task AddBodyData(Guid profileId, string userEmail, BodyDataDto bodyDataDto)
        {
            try
            {
                User user = await userRepository.FindByEmail(userEmail);
                BodyData bodyData = new(bodyDataDto.Weight, bodyDataDto.Height, bodyDataDto.FatMassRate, bodyDataDto.WaterRate, bodyDataDto.MuscleRate, bodyDataDto.BoneRate, bodyDataDto.HeartBeat, bodyDataDto.BodyMassIndex);
                user.AddBodyData(profileId, bodyData);
            }
            catch(Exception)
            {
                throw new AddingBodyDataException();
            }
            
        }
    }
}
