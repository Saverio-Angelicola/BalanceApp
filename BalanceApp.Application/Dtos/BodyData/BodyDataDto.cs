namespace BalanceApp.Application.Dtos.BodyData
{
    public record BodyDataDto
    {
        public double MuscleRate { get; set; }
        public double BoneRate { get; set; }
        public double HeartBeat { get; set; }
        public double BodyMassIndex { get; set; }
        public double WaterRate { get; set; }
        public double FatMassRate { get; set; }
        public double Weight { get; set; }

        public BodyDataDto(double muscleRate, double boneRate, double heartBeat, double bodyMassIndex, double waterRate, double fatMassRate, double weight)
        {
            MuscleRate = muscleRate;
            BoneRate = boneRate;
            HeartBeat = heartBeat;
            BodyMassIndex = bodyMassIndex;
            WaterRate = waterRate;
            FatMassRate = fatMassRate;
            Weight = weight;
        }

        public BodyDataDto()
        {
            MuscleRate = 0.0;
            BoneRate = 0.0;
            HeartBeat = 0.0;
            BodyMassIndex = 0.0;
            WaterRate = 0.0;
            FatMassRate = 0.0;
            Weight = 0.0;
        }
    }
}
