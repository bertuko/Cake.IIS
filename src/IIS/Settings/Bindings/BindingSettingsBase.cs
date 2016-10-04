using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Base class to configure any type of IIS binding (secure or not).
    /// </summary>
    public abstract class BindingSettingsBase
    {
        /// <summary>
        /// Creates new instance of <see cref="BindingSettingsBase"/>.
        /// </summary>
        /// <param name="bindingProtocol">Binding type.</param>
        public BindingSettingsBase(BindingProtocol bindingProtocol)
        {
            this.BindingProtocol = bindingProtocol;
        }

        /// <inheritdoc cref="IIpAddressBindingSettings.IpAddress"/>
        public string IpAddress { get; set; }

        /// <inheritdoc cref="IPortBindingSettings.Port"/>
        public int Port { get; set; }

        /// <inheritdoc cref="IHostBindingSettings.HostName"/>
        public string HostName { get; set; }

        /// <inheritdoc cref="ICertificateBindingSettings.CertificateHash"/>
        public byte[] CertificateHash { get; set; }

        /// <inheritdoc cref="ICertificateBindingSettings.CertificateStoreName"/>
        public string CertificateStoreName { get; set; }

        /// <inheritdoc cref="IBindingSettings.BindingProtocol"/>
        public BindingProtocol BindingProtocol { get; private set; }

        /// <inheritdoc cref="IBindingSettings.BindingInformation"/>
        public virtual string BindingInformation
        {
            get
            {
                return string.Format(@"{0}:{1}:{2}", IpAddress, Port, HostName);
            }
        }
    }
}