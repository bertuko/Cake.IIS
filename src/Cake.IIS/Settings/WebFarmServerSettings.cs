namespace Cake.IIS
{
    /// <summary>
    /// Settings to configure a WebFarm Server
    /// </summary>
    public class WebFarmServerSettings
    {
        #region Constructor
        public WebFarmServerSettings()
        {
        }
        #endregion





        #region Properties
        /// <summary>
        /// Server address
        /// </summary>
        public string Address { get; set; }



        /// <summary>
        /// Server HTTP port
        /// </summary>
        public int? HttpPort { get; set; }

        /// <summary>
        /// Server HTTPS port
        /// </summary>
        public int? HttpsPort { get; set; }



        /// <summary>
        /// Server Weight
        /// </summary>
        public int? Weight { get; set; }
        #endregion
    }
}