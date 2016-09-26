using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to configure net.pipe binding.
    /// </summary>
    public sealed class NetPipeBindingSettings : BindingSettingsBase, INetPipeBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="NetPipeBindingSettings"/>.
        /// </summary>
        public NetPipeBindingSettings() : base(BindingProtocol.NetPipe)
        {
            HostName = "*";
        }

        /// <inheritdoc cref="IBindingSettings.BindingInformation"/>
        public override string BindingInformation
        {
            get { return string.Format("{0}", HostName); }
        }
    }
}