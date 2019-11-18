namespace GieldaL2.INFRASTRUCTURE.DTO
{
    /// <summary>
    /// Data transfer object used during authentication.
    /// </summary>
    public class AuthDTO
    {
        /// <summary>
        /// Username.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}
