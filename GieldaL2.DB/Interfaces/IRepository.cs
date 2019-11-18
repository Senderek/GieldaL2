namespace GieldaL2.DB.Interfaces
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Time of the last database operation (it was easier to do it this way instead of creating "out int time" in the every
        /// method because out variables cannot be assigned to the class members which is done in the services).
        /// </summary>
        int LastOperationTime { get; set; }
    }
}
