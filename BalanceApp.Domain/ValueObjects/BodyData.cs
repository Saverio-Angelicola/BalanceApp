using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Domain.ValueObjects
{
    public record BodyData
    {
        public double Weight { get; }
        public double FatMassRate { get; }
        public double WaterRate { get; }
        public double MuscleRate { get; }
        public double BoneRate { get; }
        public double HeartBeat { get; }
        public double BodyMassIndex { get; }
        public DateTime CreatedAt { get; }

        public BodyData(double weight, double fatMassRate, double waterRate, double muscleRate, double boneRate, double heartBeat, double bodyMassIndex, DateTime createdAt)
        {
            Weight = weight;
            FatMassRate = fatMassRate;
            WaterRate = waterRate;
            MuscleRate = muscleRate;
            BoneRate = boneRate;
            HeartBeat = heartBeat;
            BodyMassIndex = bodyMassIndex;
            CreatedAt = createdAt;
        }
    }
}
