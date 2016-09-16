namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to represent and configure https binding.
    /// </summary>
    public sealed class HttpsBindingSettings : ISecureBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="HttpsBindingSettings"/>.
        /// </summary>
        public HttpsBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.Https;
            this.HostName = "*";
            this.IpAddress = "*";
            this.Port = 443;
        }

        /// <summary>
        /// Gets or sets Host Name for binding.
        /// </summary>
        /// <returns>The Host Name of binding. Default: <c>*</c>.</returns>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets IP Address
        /// </summary>
        /// <returns>The IP Address. Default: <c>*</c>.</returns>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets IP Port number
        /// </summary>
        /// <returns>The Port number. Default: <c>443</c>.</returns>
        public int Port { get; set; }

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

        /// <inheritdoc />
        public byte[] CertificateHash { get; set; }

        /// <inheritdoc />
        public string CertificateStoreName { get; set; }
    }
}