#region Using Statements
using Cake.Core;
using Cake.Core.Annotations;

using Microsoft.Web.Administration;
#endregion



namespace Cake.IIS
{
    /// <summary>
    /// Contains aliases for working with IIS rewrite.
    /// </summary>
    [CakeAliasCategory("IIS")]
    [CakeNamespaceImport("Microsoft.Web.Administration")]
    public static class RewriteAliases
    {
        /// <summary>
        /// Creates a rewrite rule on local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The rewrite rule settings.</param>
        [CakeMethodAlias]
        public static void CreateRewriteRule(this ICakeContext context, RewriteRuleSettings settings)
        {
            context.CreateRewriteRule("", settings);
        }

        /// <summary>
        /// Creates a rewrite rule on remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="settings">The rewrite rule settings.</param>
        [CakeMethodAlias]
        public static void CreateRewriteRule(this ICakeContext context, string server, RewriteRuleSettings settings)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                RewriteManager
                    .Using(context.Environment, context.Log, manager)
                    .CreateRule(settings);
            }
        }

        /// <summary>
        /// Deletes a rewrite rule from local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The rule name.</param>
        /// <returns><c>true</c> if deleted</returns>
        [CakeMethodAlias]
        public static bool DeleteRewriteRule(this ICakeContext context, string name)
        {
            return context.DeleteRewriteRule("", name);
        }

        /// <summary>
        /// Deletes a rewrite rule from remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="name">The rule name.</param>
        /// <returns><c>true</c> if deleted</returns>
        [CakeMethodAlias]
        public static bool DeleteRewriteRule(this ICakeContext context, string server, string name)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                return RewriteManager
                    .Using(context.Environment, context.Log, manager)
                    .DeleteRule(name);
            }
        }

        /// <summary>
        /// Checks if rule exists on local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The rewrite rule name.</param>
        /// <returns><c>true</c> if exists</returns>
        [CakeMethodAlias]
        public static bool RuleExists(this ICakeContext context, string name)
        {
            return context.RuleExists("", name);
        }

        /// <summary>
        /// Checks if rule exists on remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote IIS server name.</param>
        /// <param name="name">The rewrite rule name.</param>
        /// <returns><c>true</c> if exists</returns>
        [CakeMethodAlias]
        public static bool RuleExists(this ICakeContext context, string server, string name)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                return RewriteManager
                    .Using(context.Environment, context.Log, manager)
                    .Exists(name);
            }
        }
    }
}
