namespace Cake.IIS
{
    public class WebFarmSettings
    {
        #region Constructor
        public WebFarmSettings()
        {

        }
        #endregion





        #region Properties
        public string Name { get; set; }

        public string[] Servers { get; set; }
        


        public bool Overwrite { get; set; }
        #endregion
    }
}