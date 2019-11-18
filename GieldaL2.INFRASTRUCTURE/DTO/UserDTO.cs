using System;

namespace GieldaL2.INFRASTRUCTURE.DTO
{
    /// <summary>
    /// User data transfer object
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// User's ID in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User's surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// User's login used in the authentication.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// User's e-mail.
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// User's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// User's total money.
        /// </summary>
        public decimal Value { get; set; }
    }
}
