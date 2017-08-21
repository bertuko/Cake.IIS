using System.Collections.Generic;

namespace Cake.IIS
{
    public class WebsiteWebConfigurationSettings : WebConfigurationSettings
    {
        public string SiteName { get; set; }
    }

    public class ApplicationWebConfigurationSettings : WebsiteWebConfigurationSettings
    {
        public string ApplicationPath { get; set; }
    }

    public abstract class WebConfigurationSettings
    {
        protected WebConfigurationSettings()
        {
            ConfigurationValues = new List<WebConfigurationValue>();
        }

        public List<WebConfigurationValue> ConfigurationValues { get; set; }
    }

    public class WebConfigurationValue
    {
        public string Section { get; set; }
        public string Key { get; set; }
        public object Value { get; set; }
    }

    public static class WebConfigurationSettingsExtensions
    {
        public static T AddConfigurationValue<T>(this T webConfigurationSettings, WebConfigurationValue value) where T : WebConfigurationSettings
        {
            webConfigurationSettings.ConfigurationValues.Add(value);
            return webConfigurationSettings;
        }

        public static T AddConfigurationValue<T>(this T webConfigurationSettings, string section, string key, object value) where T : WebConfigurationSettings
        {
            webConfigurationSettings.ConfigurationValues.Add(new WebConfigurationValue { Section = section, Key = key, Value = value });
            return webConfigurationSettings;
        }

        public static T EnableDirectoryBrowsing<T>(this T webConfigurationSettings, bool enable) where T : WebConfigurationSettings
        {
            webConfigurationSettings.ConfigurationValues.Add(new WebConfigurationValue { Section = "system.webServer/directoryBrowse", Key = "enabled", Value = enable });
            webConfigurationSettings.ConfigurationValues.Add(new WebConfigurationValue { Section = "system.webServer/directoryBrowse", Key = "showFlags", Value = "Date, Time, Size, Extension" });
            return webConfigurationSettings;
        }
    }
}
