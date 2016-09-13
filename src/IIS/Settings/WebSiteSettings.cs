using Cake.IIS.Settings.Bindings;

namespace Cake.IIS
{
    public class WebsiteSettings : SiteSettings
    {
        #region Constructor (1)
            public WebsiteSettings()
                : base()
            {
                this.DefaultBinding = new HttpBindingSettings();
            }
        #endregion
    }
}
