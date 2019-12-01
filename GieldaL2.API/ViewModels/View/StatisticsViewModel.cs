namespace GieldaL2.API.ViewModels.View
{
    public class StatisticsViewModel
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

	public class StatisticsViewModel<T>
	{
		/// <summary>
		/// Time the request been processed. **This field is populated automatically by BackendTimeFilter**
		/// </summary>
		public float BackendTime { get; set; }
		/// <summary>
		/// Represents time it took DB to perform SELECT queries.
		/// </summary>
		public float SelectsTime { get; set; }
		public int SelectsCount { get; set; }
		/// <summary>
		/// Represents time it took DB to perform UPDATE queries.
		/// </summary>
		public float UpdatesTime { get; set; }
		public int UpdatesCount { get; set; }
		/// <summary>
		/// Represents time it took DB to perform INSERT queries.
		/// </summary>
		public float InsertsTime { get; set; }
        public int InsertsCount { get; set; }
		/// <summary>
		/// Represents time it took DB to perform DELETE queries.
		/// </summary>
		public float DeletesTime { get; set; }
        public int DeletesCount { get; set; }
		/// <summary>
		/// Actual data of a response
		/// </summary>
		public T Data { get; set; }
	}
}
