#region Using Statements
using System;
using Cake.Core;
using Cake.Core.Annotations;

using Microsoft.Web.Administration;
#endregion



namespace Cake.IIS.Aliases
{
    /// <summary>
    /// Contains aliases for working with IIS configuration files
    /// </summary>
    [CakeAliasCategory("IIS")]
    [CakeNamespaceImport("Microsoft.Web.Administration")]
    public static class WebConfigurationAliases
    {
        /// <summary>
        /// Set the configuration for a host.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configuration">The IIS configuration settings.</param>
        [CakeMethodAlias]
        public static void SetHostWebConfiguration(this ICakeContext context, Action<Configuration> configuration)
        {
            context.SetHostWebConfiguration("", configuration);
        }

        /// <summary>
        /// Set the configuration for a host.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="configuration">The IIS configuration settings.</param>
        [CakeMethodAlias]
        public static void SetHostWebConfiguration(this ICakeContext context, string server, Action<Configuration> configuration)
        {
            using (var manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .SetWebConfiguration(null, null, configuration);
            }
        }



        /// <summary>
        /// Set the configuration for a site.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="siteName">The web site name.</param>
        /// <param name="configuration">The IIS configuration settings.</param>
        [CakeMethodAlias]
        public static void SetSiteWebConfiguration(this ICakeContext context, string siteName, Action<Configuration> configuration)
        {
            context.SetSiteWebConfiguration("", siteName, configuration);
        }

        /// <summary>
        /// Set the configuration for a site.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="siteName">The web site name.</param>
        /// <param name="configuration">The IIS configuration settings.</param>
        [CakeMethodAlias]
        public static void SetSiteWebConfiguration(this ICakeContext context, string server, string siteName, Action<Configuration> configuration)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .SetWebConfiguration(siteName, null, configuration);
            }
        }



        /// <summary>
        /// Set the configuration for an application.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="siteName">The web site name.</param>
        /// <param name="applicationPath">The virtual application within the site.</param>
        /// <param name="configuration">The IIS configuration settings.</param>
        [CakeMethodAlias]
        public static void SetApplicationWebConfiguration(this ICakeContext context, string siteName, string applicationPath, Action<Configuration> configuration)
        {
            context.SetApplicationWebConfiguration("", siteName, applicationPath, configuration);
        }

        /// <summary>
        /// Set the configuration for an application.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="siteName">The web site name.</param>
        /// <param name="applicationPath">The virtual application within the site.</param>
        /// <param name="configuration">The IIS configuration settings.</param>
        [CakeMethodAlias]
        public static void SetApplicationWebConfiguration(this ICakeContext context, string server, string siteName, string applicationPath, Action<Configuration> configuration)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .SetWebConfiguration(siteName, applicationPath, configuration);
            }
        }
    }
}
