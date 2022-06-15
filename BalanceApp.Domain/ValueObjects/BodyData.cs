namespace BalanceApp.Domain.ValueObjects
{
    public record BodyData
    {
        public double Weight { get; }
        public double FatMassRate { get; }
        public double WaterRate { get; }
        public double MuscleRate { get; }
        public double BoneRate { get; }
        public double BodyMassIndex { get; }
        public string CreatedAt { get; }

        public BodyData()
        {
            Weight = 0;
            FatMassRate = 0;
            WaterRate = 0;
            MuscleRate = 0;
            BoneRate = 0;
            BodyMassIndex = 0;
            CreatedAt = string.Empty;
        }

        public BodyData(double weight, double fatMassRate, double waterRate, double muscleRate, double boneRate, double bodyMassIndex, string createdAt)
        {
            Weight = weight;
            FatMassRate = fatMassRate;
            WaterRate = waterRate;
            MuscleRate = muscleRate;
            BoneRate = boneRate;
            BodyMassIndex = bodyMassIndex;
            CreatedAt = createdAt;
        }
    }
}
