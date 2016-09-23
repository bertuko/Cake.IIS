using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to represent and configure any type of IIS binding (secure or not).
    /// </summary>
    public class CustomBindingSettings : ICustomBindingSettings, ISecureBindingSettings
    {
        /// <summary>
        /// Creates new instance of <see cref="CustomBindingSettings"/>.
        /// </summary>
        /// <param name="bindingProtocol">Binding type.</param>
        public CustomBindingSettings(BindingProtocol bindingProtocol)
        {
            this.BindingProtocol = bindingProtocol;
        }

        /// <summary>
        /// Gets or sets IP Address
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets IP Port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets Host Name for binding
        /// </summary>
        public string HostName { get; set; }

        /// <inheritdoc />
        public byte[] CertificateHash { get; set; }

        /// <inheritdoc />
        public string CertificateStoreName { get; set; }

        /// <inheritdoc />
        public BindingProtocol BindingProtocol { get; set; }

        /// <inheritdoc />
        public virtual string BindingInformation
        {
            get
            {
                return string.Format(@"{0}:{1}:{2}", IpAddress, Port, HostName);
            }
        }

        ICustomBindingSettings ICustomBindingSettings.Port(int port)
        {
            Port = port;
            return this;
        }

        ICustomBindingSettings ICustomBindingSettings.HostName(string name)
        {
            HostName = name;
            return this;
        }

        ICustomBindingSettings ICustomBindingSettings.IpAddress(string ipAddress)
        {
            IpAddress = ipAddress;
            return this;
        }

        ICustomBindingSettings ICustomBindingSettings.CertificateStoreName(string storeName)
        {
            CertificateStoreName = storeName;
            return this;
        }

        ICustomBindingSettings ICustomBindingSettings.CertificateHash(byte[] hash)
        {
            CertificateHash = hash;
            return this;
        }

        CustomBindingSettings ICustomBindingSettings.Instance
        {
            get { return this; }
        }
    }
}