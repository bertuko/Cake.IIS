using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to represent and configure net.pipe binding.
    /// </summary>
    public sealed class NetPipeBindingSettings : INetPipeBindingSettings, IBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="NetPipeBindingSettings"/>.
        /// </summary>
        public NetPipeBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.NetPipe;
            this.HostName = "*";
        }

        /// <summary>
        /// Gets or sets Host Name for binding.
        /// </summary>
        /// <returns>The Host Name of binding. Default: <c>*</c>.</returns>
        public string HostName { get; set; }

        /// <inheritdoc />
        public BindingProtocol BindingProtocol { get; private set; }

        /// <inheritdoc />
        public string BindingInformation
        {
            get { return string.Format("{0}", HostName); }
        }

        INetPipeBindingSettings INetPipeBindingSettings.HostName(string name)
        {
            HostName = name;
            return this;
        }

        NetPipeBindingSettings INetPipeBindingSettings.Instance
        {
            get { return this; }
        }
    }
}