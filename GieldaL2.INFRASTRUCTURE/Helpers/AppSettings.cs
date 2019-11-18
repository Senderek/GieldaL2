using System;
using System.Collections.Generic;
using System.Text;

namespace GieldaL2.INFRASTRUCTURE.Helpers
{
    /// <summary>
    /// Data read from the appsettings.json file.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Secret key used in the JWT authentication.
        /// </summary>
        public string Secret { get; set; }
    }
}
