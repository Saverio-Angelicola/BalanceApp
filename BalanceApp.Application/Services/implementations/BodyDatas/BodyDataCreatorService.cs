using BalanceApp.Application.Dtos.BodyData;
using BalanceApp.Application.Exceptions;
using BalanceApp.Application.Repositories;
using BalanceApp.Domain.Entities;
using BalanceApp.Domain.ValueObjects;

namespace BalanceApp.Application.Services.implementations.BodyDatas
{
    public class BodyDataCreatorService
    {
        private readonly IUserRepository userRepository;

        public BodyDataCreatorService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async void AddBodyData(Guid profileId, string userEmail, BodyDataDto bodyDataDto)
        {
                User? user = await userRepository.FindByEmail(userEmail);
                if (user is null)
                {
                    throw new UserNotFoundException(userEmail);
                }

                BodyData bodyData = new(bodyDataDto.Weight, bodyDataDto.Height, bodyDataDto.FatMassRate, bodyDataDto.WaterRate, bodyDataDto.MuscleRate, bodyDataDto.BoneRate, bodyDataDto.HeartBeat, bodyDataDto.BodyMassIndex);
                user.AddBodyData(profileId, bodyData);
        }


    }
}
