#region Using Statements
    using System;
    using Cake.Core;
    using Cake.Core.Annotations;
    using Cake.IIS.Settings;
    using Cake.IIS.Settings.Bindings;
    using Cake.IIS.Settings.Bindings.FluentAPI;
    using Microsoft.Web.Administration;
#endregion



namespace Cake.IIS
{
    /// <summary>
    /// Contains aliases for working with IIS sites.
    /// </summary>
    [CakeAliasCategory("IIS")]
    [CakeNamespaceImport("Microsoft.Web.Administration")]
    public static class SiteAliases
    {
        /// <summary>
        /// Gets pre-defined bindings
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>Predefined bindings for IIS</returns>
        [CakePropertyAlias]
        public static IBindings IISBindings(this ICakeContext context)
        {
            return new IISBindings();
        }

        /// <summary>
        /// Checks if site exists on local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if exists</returns>
        [CakeMethodAlias]
        public static bool SiteExists(this ICakeContext context, string name)
        {
            return context.SiteExists("", name);
        }

        /// <summary>
        /// Checks if site exists on remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if exists</returns>
        [CakeMethodAlias]
        public static bool SiteExists(this ICakeContext context, string server, string name)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                return WebsiteManager
                        .Using(context.Environment, context.Log, manager)
                        .Exists(name);
            }
        }

        /// <summary>
        /// Deletes site from local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if deleted</returns>
        [CakeMethodAlias]
        public static bool DeleteSite(this ICakeContext context, string name)
        {
            return context.DeleteSite("", name);
        }

        /// <summary>
        /// Deletes site from remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if deleted</returns>
        [CakeMethodAlias]
        public static bool DeleteSite(this ICakeContext context, string server, string name)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                return WebsiteManager
                        .Using(context.Environment, context.Log, manager)
                        .Delete(name);
            }
        }

        /// <summary>
        /// Starts site on local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if started</returns>
        [CakeMethodAlias]
        public static bool StartSite(this ICakeContext context, string name)
        {
            return context.StartSite("", name);
        }

        /// <summary>
        /// Starts site on remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if started</returns>
        [CakeMethodAlias]
        public static bool StartSite(this ICakeContext context, string server, string name)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                return WebsiteManager
                        .Using(context.Environment, context.Log, manager)
                        .Start(name);
            }
        }

        /// <summary>
        /// Stops site on local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if stopped</returns>
        [CakeMethodAlias]
        public static bool StopSite(this ICakeContext context, string name)
        {
            return context.StopSite("", name);
        }

        /// <summary>
        /// Stops site on remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if stopped</returns>
        [CakeMethodAlias]
        public static bool StopSite(this ICakeContext context, string server, string name)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                return WebsiteManager
                        .Using(context.Environment, context.Log, manager)
                        .Stop(name);
            }
        }

        /// <summary>
        /// Restarts site on local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if restarted</returns>
        [CakeMethodAlias]
        public static bool RestartSite(this ICakeContext context, string name)
        {
            return context.RestartSite("", name);
        }

        /// <summary>
        /// Restarts site on remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="name">The site name.</param>
        /// <returns><c>true</c> if restarted</returns>
        [CakeMethodAlias]
        public static bool RestartSite(this ICakeContext context, string server, string name)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager webManager = WebsiteManager.Using(context.Environment, context.Log, manager);

                if (webManager.Stop(name))
                {
                    return webManager.Start(name);
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Add site binding to local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The site binding settings.</param>
        [CakeMethodAlias]
        [Obsolete("Use AddBinding method instead.")]
        public static void AddSiteBinding(this ICakeContext context, BindingSettings settings)
        {
            context.AddSiteBinding("", settings);
        }

        /// <summary>
        /// Add site binding to remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="settings">The site binding settings.</param>
        [CakeMethodAlias]
        [Obsolete("Use AddBinding method instead.")]
        public static void AddSiteBinding(this ICakeContext context, string server, BindingSettings settings)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .AddBinding(settings.Name, settings);
            }
        }

        /// <summary>
        /// Add site binding to local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="siteName">The site name.</param>
        /// <param name="settings">The binding settings.</param>
        [CakeMethodAlias]
        public static void AddBinding(this ICakeContext context, string siteName, IBindingSettings settings)
        {
            context.AddBinding("", siteName, settings);
        }

        /// <summary>
        /// Add site binding to remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="siteName">The site name.</param>
        /// <param name="settings">The binding settings.</param>
        [CakeMethodAlias]
        public static void AddBinding(this ICakeContext context, string server, string siteName, IBindingSettings settings)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .AddBinding(siteName, settings);
            }
        }

        /// <summary>
        /// Removes site binding from local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="siteName">The site name.</param>
        /// <param name="settings">The binding settings.</param>
        [CakeMethodAlias]
        [Obsolete("Use RemoveBinding method instead.")]
        public static void RemoveSiteBinding(this ICakeContext context, string siteName, BindingSettings settings)
        {
            context.RemoveSiteBinding("", siteName, settings);
        }

        /// <summary>
        /// Removes site binding from remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="siteName">The site name.</param>
        /// <param name="settings">The binding settings.</param>
        [CakeMethodAlias]
        [Obsolete("Use RemoveBinding method instead.")]
        public static void RemoveSiteBinding(this ICakeContext context, string server, string siteName, BindingSettings settings)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .RemoveBinding(siteName, settings);
            }
        }

        /// <summary>
        /// Removes site binding from local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="siteName">The site name.</param>
        /// <param name="settings">The binding settings.</param>
        [CakeMethodAlias]
        public static void RemoveBinding(this ICakeContext context, string siteName, IBindingSettings settings)
        {
            context.RemoveBinding("", siteName, settings);
        }

        /// <summary>
        /// Removes site binding from remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="siteName">The site name.</param>
        /// <param name="settings">The binding settings.</param>
        [CakeMethodAlias]
        public static void RemoveBinding(this ICakeContext context, string server, string siteName, IBindingSettings settings)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .RemoveBinding(siteName, settings);
            }
        }

        /// <summary>
        /// Adds site application to local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The site binding settings.</param>
        [CakeMethodAlias]
        public static void AddSiteApplication(this ICakeContext context, ApplicationSettings settings)
        {
            context.AddSiteApplication("", settings);
        }

        /// <summary>
        /// Adds site application to remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="settings">The site binding settings.</param>
        [CakeMethodAlias]
        public static void AddSiteApplication(this ICakeContext context, string server, ApplicationSettings settings)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                settings.ComputerName = server;

                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .AddApplication(settings);
            }
        }

        /// <summary>
        /// Removes site application from local IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The site binding settings.</param>
        [CakeMethodAlias]
        public static void RemoveSiteApplication(this ICakeContext context, ApplicationSettings settings)
        {
            context.RemoveSiteApplication("", settings);
        }

        /// <summary>
        /// Removes site application from remote IIS.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="server">The remote server name.</param>
        /// <param name="settings">The site binding settings.</param>
        [CakeMethodAlias]
        public static void RemoveSiteApplication(this ICakeContext context, string server, ApplicationSettings settings)
        {
            using (ServerManager manager = BaseManager.Connect(server))
            {
                WebsiteManager
                    .Using(context.Environment, context.Log, manager)
                    .RemoveApplication(settings);
            }
        }
    }
}
