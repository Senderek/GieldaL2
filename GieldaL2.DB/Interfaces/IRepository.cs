namespace GieldaL2.DB.Interfaces
{
    /// <summary>
    /// Marked interface fo dependency injection resolve
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Declaration of property that store last operation time on database
        /// </summary>
        int LastOperationTime { get; set; }
    }
}
