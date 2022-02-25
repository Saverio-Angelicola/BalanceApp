using BalanceApp.Domain.Exceptions;

namespace BalanceApp.Domain.ValueObjects
{
    public record BodyData
    {
        public double Weight { get; }
        public double Height { get; }
        public double FatMassRate { get; }
        public double WaterRate { get; }
        public double MuscleRate { get; }
        public double BoneRate { get; }
        public double HeartBeat { get; }
        public double BodyMassIndex { get; }
        public DateTime CreatedAt { get; }

        public BodyData(double weight, double height, double fatMassRate, double waterRate, double muscleRate, double boneRate, double heartBeat, double bodyMassIndex)
        {
            if (weight <= 0 && height <= 0 && fatMassRate < 0 && waterRate < 0 && muscleRate < 0 && boneRate < 0 && heartBeat < 0 && bodyMassIndex < 0)
            {
                throw new BodyDataPositiveValueException();
            }
            Weight = weight;
            Height = height;
            FatMassRate = fatMassRate;
            WaterRate = waterRate;
            MuscleRate = muscleRate;
            BoneRate = boneRate;
            HeartBeat = heartBeat;
            BodyMassIndex = bodyMassIndex;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
