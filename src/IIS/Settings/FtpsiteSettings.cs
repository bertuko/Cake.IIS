using Cake.IIS.Settings.Bindings;

namespace Cake.IIS
{
    public class FtpsiteSettings : SiteSettings
    {
        #region Constructor (1)
            public FtpsiteSettings()
                : base()
            {
                DefaultBinding = new CustomBindingSettings(BindingProtocol.Ftp)
                {
                    Port = 21,
                };
            }
        #endregion
    }
}
