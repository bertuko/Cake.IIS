namespace Cake.IIS
{
    public class WebFarmServerSettings
    {
        #region Constructor
        public WebFarmServerSettings()
        {
        }
        #endregion





        #region Properties
        public string Address { get; set; }

        public int? HttpPort { get; set; }

        public int? HttpsPort { get; set; }

        public int? Weight { get; set; }
        #endregion
    }
}