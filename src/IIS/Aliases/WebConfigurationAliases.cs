#region Using Statements
using System;
using Cake.Core;
using Cake.Core.Annotations;
using Microsoft.Web.Administration;
#endregion

namespace Cake.IIS.Aliases
{
    /// <summary>
    /// Contains aliases for working with IIS virtual applications.
    /// </summary>
    [CakeAliasCategory("IIS")]
    [CakeNamespaceImport("Microsoft.Web.Administration")]
    public static class WebConfigurationAliases
    {
        [CakeMethodAlias]
        public static void SetHostWebConfiguration(this ICakeContext context, Action<Configuration> configurationAction)
        {
            context.SetHostWebConfiguration("", configurationAction);
        }

        [CakeMethodAlias]
        public static void SetHostWebConfiguration(this ICakeContext context, string server, Action<Configuration> configurationAction)
        {
            using (var manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .SetWebConfiguration(null, null, configurationAction);
            }
        }

        [CakeMethodAlias]
        public static void SetSiteWebConfiguration(this ICakeContext context, string siteName, Action<Configuration> configurationAction)
        {
            context.SetSiteWebConfiguration("", siteName, configurationAction);
        }

        [CakeMethodAlias]
        public static void SetSiteWebConfiguration(this ICakeContext context, string server, string siteName, Action<Configuration> configurationAction)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .SetWebConfiguration(siteName, null, configurationAction);
            }
        }

        [CakeMethodAlias]
        public static void SetApplicationWebConfiguration(this ICakeContext context, string siteName, string applicationPath,  Action<Configuration> configurationAction)
        {
            context.SetApplicationWebConfiguration("", siteName, applicationPath, configurationAction);
        }

        [CakeMethodAlias]
        public static void SetApplicationWebConfiguration(this ICakeContext context, string server, string siteName, string applicationPath, Action<Configuration> configurationAction)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .SetWebConfiguration(siteName, applicationPath, configurationAction);
            }
        }
    }
}
