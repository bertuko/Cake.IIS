namespace Cake.IIS
{
    public class WebsiteSettings : SiteSettings
    {
        #region Constructors
        public WebsiteSettings()
            : base()
        {
            Binding = IISBindings.Http;
        }
        #endregion





        #region Properties
        /// <summary>
        /// Flag to get or set of directory browsing should be enabled.
        /// </summary>
        public bool EnableDirectoryBrowsing { get; set; }
        #endregion
    }
}
