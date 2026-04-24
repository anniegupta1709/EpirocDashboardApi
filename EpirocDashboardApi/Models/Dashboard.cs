namespace EpirocDashboardApi.Models
{
    public class Dashboard
    {
        public string Id { get; set; } = "1";
        public int Rpm { get; set; }
        public int Battery { get; set; }
        public int Temperature { get; set; }
        public int Power { get; set; }
        public double GearRatio { get; set; }
        public int Speed { get; set; }
        public bool IsCharging { get; set; }
        public bool Brake { get; set; }
        public bool EngineCheck { get; set; }
    }
}
