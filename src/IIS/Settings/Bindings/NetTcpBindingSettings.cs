using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to configure net.tcp binding.
    /// </summary>
    public sealed class NetTcpBindingSettings : BindingSettingsBase, INetTcpBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="NetTcpBindingSettings"/>.
        /// </summary>
        public NetTcpBindingSettings() : base(BindingProtocol.NetTcp)
        {
            this.Port = 808;
            this.HostName = "*";
        }

        /// <inheritdoc cref="IBindingSettings.BindingInformation"/>
        public override string BindingInformation
        {
            get { return string.Format("{0}:{1}", Port, HostName); }
        }
    }
}