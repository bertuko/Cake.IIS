using System;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to represent and configure any type of IIS binding (secure or not).
    /// </summary>
    /// <remarks>
    /// This class is obsolete and may be removed in future releases.
    /// Please use it only to add/remove the binding by:
    /// <see cref="SiteAliases.AddSiteBinding(Cake.Core.ICakeContext,Cake.IIS.Settings.Bindings.BindingSettings)"/>
    /// <see cref="SiteAliases.AddSiteBinding(Cake.Core.ICakeContext,string,Cake.IIS.Settings.Bindings.BindingSettings)"/>
    /// <see cref="SiteAliases.RemoveSiteBinding(Cake.Core.ICakeContext,string,Cake.IIS.Settings.Bindings.BindingSettings)"/>
    /// <see cref="SiteAliases.RemoveSiteBinding(Cake.Core.ICakeContext,string,string,Cake.IIS.Settings.Bindings.BindingSettings)"/>
    /// </remarks>
    [Obsolete("Use CustomBindingSettings class")]
    public class BindingSettings : CustomBindingSettings
    {
        /// <summary>
        /// Creates new instance of <see cref="BindingSettings"/>.
        /// </summary>
        public BindingSettings() : base(BindingProtocol.Http)
        {
            IpAddress = "*";
            Port = 80;
            HostName = "*";
        }

        /// <summary>
        /// Gets or sets site name.
        /// </summary>
        public string Name { get; set; }
    }
}