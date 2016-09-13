namespace Cake.IIS
{
    public class FtpsiteSettings : SiteSettings
    {
        #region Constructor (1)
            public FtpsiteSettings()
                : base()
            {
                DefaultBindingSettings = new BindingSettings
                {
                    BindingProtocol = BindingProtocol.Ftp,
                    Port = 21,
                };
            }
        #endregion
    }
}
