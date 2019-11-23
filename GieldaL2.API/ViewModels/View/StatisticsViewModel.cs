namespace GieldaL2.API.ViewModels.View
{
    public class StatisticsViewModel
    {
        public int BackendTime { get; set; }

        public int SelectsTime { get; set; }
        public int SelectsCount { get; set; }

        public int UpdatesTime { get; set; }
        public int UpdatesCount { get; set; }

        public int InsertsTime { get; set; }
        public int InsertsCount { get; set; }

        public int DeletesTime { get; set; }
        public int DeletesCount { get; set; }
    }

	public class StatisticsViewModel<T>
	{
		public int BackendTime { get; set; }

		public int SelectsTime { get; set; }
		public int SelectsCount { get; set; }

		public int UpdatesTime { get; set; }
		public int UpdatesCount { get; set; }

        public int InsertsTime { get; set; }
        public int InsertsCount { get; set; }

        public int DeletesTime { get; set; }
        public int DeletesCount { get; set; }

        public T Data { get; set; }
	}
}
