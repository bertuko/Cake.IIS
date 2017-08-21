#region Using Statements
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
        public static void SetSiteWebConfiguration(this ICakeContext context, WebsiteWebConfigurationSettings settings)
        {
            context.SetSiteWebConfiguration("", settings);
        }

        [CakeMethodAlias]
        public static void SetSiteWebConfiguration(this ICakeContext context, string server, WebsiteWebConfigurationSettings settings)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .SetWebConfiguration(settings);
            }
        }

        [CakeMethodAlias]
        public static void SetApplicationWebConfiguration(this ICakeContext context, ApplicationWebConfigurationSettings settings)
        {
            context.SetApplicationWebConfiguration("", settings);
        }

        [CakeMethodAlias]
        public static void SetApplicationWebConfiguration(this ICakeContext context, string server, ApplicationWebConfigurationSettings settings)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .SetWebConfiguration(settings);
            }
        }
    }
}
