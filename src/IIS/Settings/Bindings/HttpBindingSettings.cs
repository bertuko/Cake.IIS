using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to represent and configure http binding.
    /// </summary>
    public sealed class HttpBindingSettings : IHttpBindingSettings, IBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="HttpBindingSettings"/>.
        /// </summary>
        public HttpBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.Http;
            this.HostName = "*";
            this.IpAddress = "*";
            this.Port = 80;
        }

        /// <summary>
        /// Gets or sets Host Name for binding.
        /// </summary>
        /// <returns>The Host Name of binding. Default: <c>*</c>.</returns>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets IP Port number
        /// </summary>
        /// <returns>The Port number. Default: <c>80</c>.</returns>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets IP Address
        /// </summary>
        /// <returns>The IP Address. Default: <c>*</c>.</returns>
        public string IpAddress { get; set; }

        /// <inheritdoc />
        public BindingProtocol BindingProtocol { get; private set; }

        /// <inheritdoc />
        public string BindingInformation
        {
            get
            {
                return string.Format(@"{0}:{1}:{2}", IpAddress, Port, HostName);
            }
        }

        IHttpBindingSettings IHttpBindingSettings.Port(int port)
        {
            Port = port;
            return this;
        }

        IHttpBindingSettings IHttpBindingSettings.HostName(string name)
        {
            HostName = name;
            return this;
        }

        IHttpBindingSettings IHttpBindingSettings.IpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
            return this;
        }

        public HttpBindingSettings Instance
        {
            get { return this; }
        }
    }
}