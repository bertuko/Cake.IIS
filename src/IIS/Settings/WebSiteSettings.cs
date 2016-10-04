using Cake.IIS.Settings;

namespace Cake.IIS
{
    public class WebsiteSettings : SiteSettings
    {
        #region Constructor (1)
            public WebsiteSettings()
            {
                Binding = IISBindings.Http();
            }
        #endregion
    }
}
