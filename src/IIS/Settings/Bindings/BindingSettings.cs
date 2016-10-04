using System;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to configure any type of IIS binding (secure or not).
    /// </summary>
    /// <remarks>
    /// This class is obsolete and may be removed in future releases.
    /// Please use it only to add/remove the binding by:
    /// <see cref="SiteAliases.AddSiteBinding(Core.ICakeContext,BindingSettings)"/>
    /// <see cref="SiteAliases.AddSiteBinding(Core.ICakeContext,string,BindingSettings)"/>
    /// <see cref="SiteAliases.RemoveSiteBinding(Core.ICakeContext,string,BindingSettings)"/>
    /// <see cref="SiteAliases.RemoveSiteBinding(Core.ICakeContext,string,string,BindingSettings)"/>
    /// </remarks>
    [Obsolete("Use CustomBindingSettings class or IISBindings factory class.")]
    public class BindingSettings : BindingSettingsBase, ICustomBindingSettings
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