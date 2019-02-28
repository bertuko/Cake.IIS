namespace Cake.IIS
{
    public class FtpsiteSettings : SiteSettings
    {
        #region Constructors
        public FtpsiteSettings()
            : base()
        {
            this.Bindings = new BindingSettings[] { IISBindings.Ftp };
        }
        #endregion
    }
}
