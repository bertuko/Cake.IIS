#region Using Statements
using System.Collections.Generic;

using Microsoft.Web.Administration;
#endregion



namespace Cake.IIS
{
    /// <summary>
    /// Provides extension methods to modify the <see cref="Configuration"/> object.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Enables directory browsing
        /// </summary>
        /// <param name="config">The config object to adjust.</param>
        public static Configuration EnableDirectoryBrowsing(this Configuration config)
        {
            var section = config.GetSection("system.webServer/directoryBrowse");

            section["enabled"] = true;
            section["showFlags"] = "Date, Time, Size, Extension";

            return config;
        }

        /// <summary>
        /// Enables directory browsing
        /// </summary>
        /// <param name="config">The config object to adjust.</param>
        public static Configuration DisableDirectoryBrowsing(this Configuration config)
        {
            var section = config.GetSection("system.webServer/directoryBrowse");

            section["enabled"] = false;
            section["showFlags"] = "";

            return config;
        }




        /// <summary>
        /// Sets the authorization settings.
        /// </summary>
        /// <param name="config">The config object to adjust.</param>
        /// <param name="serverType">The type of the server.</param>
        /// <param name="site">The name of the site.</param>
        /// <param name="appPath">The application path.</param>
        /// <param name="settings">The authorization settings.</param>
        public static Configuration SetAuthorization(this Configuration config, string serverType, string site, string appPath, AuthorizationSettings settings)
        {
            if (settings != null)
            {
                var locationPath = site + appPath;
                var authorization = config.GetSection($"system.{serverType}/security/authorization", locationPath);
                var authCollection = authorization.GetCollection();

                var addElement = authCollection.CreateElement("add");
                addElement.SetAttributeValue("accessType", "Allow");

                switch (settings.AuthorizationType)
                {
                    case AuthorizationType.AllUsers:
                        addElement.SetAttributeValue("users", "*");
                        break;

                    case AuthorizationType.SpecifiedUser:
                        addElement.SetAttributeValue("users", string.Join(", ", settings.Users));
                        break;

                    case AuthorizationType.SpecifiedRoleOrUserGroup:
                        addElement.SetAttributeValue("roles", string.Join(", ", settings.Roles));
                        break;
                }

                // Permissions
                var permissions = new List<string>();
                if (settings.CanRead)
                {
                    permissions.Add("Read");
                }
                if (settings.CanWrite)
                {
                    permissions.Add("Write");
                }
                addElement.SetAttributeValue("permissions", string.Join(", ", permissions));

                authCollection.Clear();
                authCollection.Add(addElement);
            }
            return config;
        }

        /// <summary>
        /// Sets the authentication settings for the site.
        /// </summary>
        /// <param name="config">The config object to adjust.</param>
        /// <param name="serverType">The type of the server.</param>
        /// <param name="site">The name of the site.</param>
        /// <param name="appPath">The application path.</param>
        /// <param name="settings">The authentication settings.</param>
        /// <returns></returns>
        public static Configuration SetAuthentication(this Configuration config, string serverType, string site, string appPath, AuthenticationSettings settings)
        {
            if (settings != null)
            {
                var locationPath = site + appPath;
                var authentication = config.GetSection($"system.{serverType}/security/authorization", locationPath);

                // Anonymous Authentication
                var anonymousAuthentication = authentication.GetChildElement("anonymousAuthentication");
                anonymousAuthentication.SetAttributeValue("enabled", settings.EnableAnonymousAuthentication);

                // Basic Authentication
                var basicAuthentication = authentication.GetChildElement("basicAuthentication");
                basicAuthentication.SetAttributeValue("enabled", settings.EnableBasicAuthentication);
                basicAuthentication.SetAttributeValue("userName", settings.Username);
                basicAuthentication.SetAttributeValue("password", settings.Password);

                // Windows Authentication
                var windowsAuthentication = authentication.GetChildElement("windowsAuthentication");
                windowsAuthentication.SetAttributeValue("enabled", settings.EnableWindowsAuthentication);
            }
            return config;
        }
    }
}
