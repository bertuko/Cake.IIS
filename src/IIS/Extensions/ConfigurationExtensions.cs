using Microsoft.Web.Administration;

namespace Cake.IIS
{
    public static class ConfigurationExtensions
    {
        public static Configuration EnableDirectoryBrowsing(this Configuration config, bool enabled)
        {
            var section = config.GetSection("system.webServer/directoryBrowse");
            section["enabled"] = enabled;
            section["showFlags"] = "Date, Time, Size, Extension";
            return config;
        }
    }
}
