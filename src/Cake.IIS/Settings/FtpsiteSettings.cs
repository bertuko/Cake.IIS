namespace Cake.IIS
{
    public class FtpsiteSettings : SiteSettings
    {
        #region Constructors
        public FtpsiteSettings()
            : base()
        {
            this.Binding = IISBindings.Ftp;
        }
        #endregion
    }
}
