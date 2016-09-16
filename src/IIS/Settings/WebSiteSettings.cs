namespace Cake.IIS
{
    public class WebsiteSettings : SiteSettings
    {
        #region Constructor (1)
            public WebsiteSettings()
                : base()
            {
                ChangeBindingTo().Http()
                    .Port(80);
            }
        #endregion
    }
}
