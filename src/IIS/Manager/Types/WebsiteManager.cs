#region Using Statements

using System;
using System.Linq;
using Microsoft.Web.Administration;

using Cake.Core;
using Cake.Core.Diagnostics;
#endregion



namespace Cake.IIS
{
    /// <summary>
    /// Class for managing websites
    /// </summary>
    public class WebsiteManager : BaseSiteManager
    {
        #region Constructor (1)
        /// <summary>
        /// Initializes a new instance of the <see cref="WebsiteManager" /> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="log">The log.</param>
        public WebsiteManager(ICakeEnvironment environment, ICakeLog log)
            : base(environment, log)
        {

        }
        #endregion





        #region Methods (3)
        /// <summary>
        /// Creates a new instance of the <see cref="WebsiteManager" /> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="log">The log.</param>
        /// <param name="server">The <see cref="ServerManager" /> to connect to.</param>
        /// <returns>a new instance of the <see cref="WebFarmManager" />.</returns>
        public static WebsiteManager Using(ICakeEnvironment environment, ICakeLog log, ServerManager server)
        {
            WebsiteManager manager = new WebsiteManager(environment, log);

            manager.SetServer(server);

            return manager;
        }



        /// <summary>
        /// Creates a website
        /// </summary>
        /// <param name="settings">The settings of the website to add</param>
        public void Create(WebsiteSettings settings)
        {
            bool exists;
            Site site = base.CreateSite(settings, out exists);

            if (!exists)
            {
                _Server.CommitChanges();
                _Log.Information("Web Site '{0}' created.", settings.Name);
            }
        }

        public void SetWebConfiguration(string siteName, string applicationPath, Action<Configuration> configurationAction)
        {
            if (siteName == null)
            {
                throw new ArgumentNullException(nameof(siteName));
            }

            if (configurationAction == null)
            {
                throw new ArgumentNullException(nameof(configurationAction));
            }

            Configuration config;
            
            // Get Site
            var site = _Server.Sites.SingleOrDefault(p => p.Name == siteName);
            if (site == null)
            {
                throw new Exception("Site '" + siteName + "' does not exist.");
            }

            // Check for the application if needed
            if (applicationPath != null)
            {
                // Get Application
                var app = site.Applications.SingleOrDefault(p => p.Path == applicationPath);
                if (app == null)
                {
                    throw new Exception("Application '" + applicationPath + "' does not exist.");
                }
                config = app.GetWebConfiguration();
            }
            else
            {
                config = site.GetWebConfiguration();
            }

            configurationAction(config);
        }

        public void SetWebConfiguration(WebsiteWebConfigurationSettings settings)
        {
            Configuration config;

            // Get Site
            var site = _Server.Sites.SingleOrDefault(p => p.Name == settings.SiteName);
            if (site == null)
            {
                throw new Exception("Site '" + settings.SiteName + "' does not exist.");
            }

            // Check for the application if needed
            var applicationWebConfigSettings = settings as ApplicationWebConfigurationSettings;
            if (applicationWebConfigSettings != null)
            {
                // Get Application
                var app = site.Applications.SingleOrDefault(p => p.Path == applicationWebConfigSettings.ApplicationPath);
                if (app == null)
                {
                    throw new Exception("Application '" + applicationWebConfigSettings.ApplicationPath + "' does not exist.");
                }
                config = app.GetWebConfiguration();
            }
            else
            {
                config = site.GetWebConfiguration();
            }

            // Set all the values
            foreach (var values in settings.ConfigurationValues)
            {
                var section = config.GetSection(values.Section);
                section[values.Key] = values.Value;
            }
            // Commit the values
            _Server.CommitChanges();
        }

        #endregion
    }
}