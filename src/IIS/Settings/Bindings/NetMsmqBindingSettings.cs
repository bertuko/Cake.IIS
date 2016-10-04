using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to configure net.msmq binding.
    /// </summary>
    public sealed class NetMsmqBindingSettings : BindingSettingsBase, INetMsmqBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="NetMsmqBindingSettings"/>.
        /// </summary>
        public NetMsmqBindingSettings() : base(BindingProtocol.NetMsmq)
        {
            HostName = "localhost";
        }

        /// <inheritdoc cref="IBindingSettings.BindingInformation"/>
        public override string BindingInformation
        {
            get { return string.Format("{0}", HostName); }
        }
    }
}