#region Using Statements
using System.Collections.Generic;
using Cake.Core.Diagnostics;
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
        public static Configuration SetAuthorization(this Configuration config, string serverType, string site, string appPath, AuthorizationSettings settings, ICakeLog log)
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
        /// <param name="log">ICakeLog.</param>
        /// <returns></returns>
        public static Configuration SetAuthentication(this Configuration config, string serverType, string site, string appPath, AuthenticationSettings settings, ICakeLog log)
        {
            if (settings != null)
            {

                var sectionName = "system." + serverType + "/security/authentication/{0}";
                var location = site + appPath;

                // Anonymous Authentication
                if (settings.EnableAnonymousAuthentication.HasValue)
                {
                    var anonymousAuthentication = config.GetSection(string.Format(sectionName, "anonymousAuthentication"), location);
                    anonymousAuthentication["enabled"] = settings.EnableAnonymousAuthentication;
                    log.Information("Anonymous Authentication enabled: {0}", settings.EnableAnonymousAuthentication);
                }
                // Basic Authentication
                if (settings.EnableBasicAuthentication.HasValue)
                {
                    var basicAuthentication = config.GetSection(string.Format(sectionName, "basicAuthentication"), location);
                    basicAuthentication["enabled"] = settings.EnableBasicAuthentication;
                    log.Information("Basic Authentication enabled: {0}", settings.EnableBasicAuthentication);
                }

                // Windows Authentication
                if (settings.EnableWindowsAuthentication.HasValue)
                {
                    var windowsAuthentication = config.GetSection(string.Format(sectionName, "windowsAuthentication"), location);
                    windowsAuthentication["enabled"] = settings.EnableWindowsAuthentication;
                   log.Information("Windows Authentication enabled: {0}", settings.EnableWindowsAuthentication);
                }
            }
            return config;
        }
    }
}
