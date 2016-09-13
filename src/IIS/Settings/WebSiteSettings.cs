namespace Cake.IIS
{
    public class WebsiteSettings : SiteSettings
    {
        #region Constructor (1)
            public WebsiteSettings()
                : base()
            {
                this.DefaultBinding = new BindingSettings
                {
                    BindingProtocol = BindingProtocol.Http,
                    Port = 80
                };
            }
        #endregion
    }
}
