using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to represent and configure net.tcp binding.
    /// </summary>
    public sealed class NetTcpBindingSettings : INetTcpBindingSettings, IBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="NetTcpBindingSettings"/>.
        /// </summary>
        public NetTcpBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.NetTcp;
            this.Port = 808;
            this.HostName = "*";
        }

        /// <summary>
        /// Gets or sets Host Name for binding.
        /// </summary>
        /// <returns>The Host Name of binding. Default: <c>*</c>.</returns>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets IP Port number
        /// </summary>
        /// <returns>The Port number. Default: <c>808</c>.</returns>
        public int Port { get; set; }

        /// <inheritdoc />
        public BindingProtocol BindingProtocol { get; private set; }

        /// <inheritdoc />
        public string BindingInformation
        {
            get { return string.Format("{0}:{1}", Port, HostName); }
        }

        INetTcpBindingSettings INetTcpBindingSettings.Port(int port)
        {
            Port = port;
            return this;
        }

        INetTcpBindingSettings INetTcpBindingSettings.HostName(string name)
        {
            HostName = name;
            return this;
        }

        NetTcpBindingSettings INetTcpBindingSettings.Instance
        {
            get { return this; }
        }
    }
}