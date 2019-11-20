namespace GieldaL2.INFRASTRUCTURE.DTO
{
    public class StatisticsDTO
    {
        public float BackendTime { get; set; }

        public float SelectsTime { get; set; }
        public int SelectsCount { get; set; }

        public float UpdatesTime { get; set; }
        public int UpdatesCount { get; set; }

        public float InsertsTime { get; set; }
        public int InsertsCount { get; set; }

        public float DeletesTime { get; set; }
        public int DeletesCount { get; set; }
    }
}
