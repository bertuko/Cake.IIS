namespace Cake.IIS
{
    public class FtpsiteSettings : SiteSettings
    {
        #region Constructors (1)
        public FtpsiteSettings()
            : base()
        {
            this.Binding = IISBindings.Ftp;
        }
        #endregion
    }
}
