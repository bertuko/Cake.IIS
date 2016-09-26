namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Contains extension methods to configure bindings created by <see cref="IISBindings"/>
    /// </summary>
    public static class FluentApiExtensions
    {
        /// <summary>
        /// Specifies the host name value of the binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="hostName">The Host Name.</param>
        /// <returns>The same <see cref="IHostBindingSettings"/> instance so that multiple calls can be chained.</returns>
        public static T SetHostName<T>(this T binding, string hostName)
            where T : IHostBindingSettings
        {
            binding.HostName = hostName;
            return binding;
        }

        /// <summary>
        /// Specifies the IP Address value of the binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="ipAddress">The IP Address.</param>
        /// <returns>The same <see cref="IIpAddressBindingSettings"/> instance so that multiple calls can be chained.</returns>
        public static T SetIpAddress<T>(this T binding, string ipAddress)
            where T : IIpAddressBindingSettings
        {
            binding.IpAddress = ipAddress;
            return binding;
        }

        /// <summary>
        /// Specifies the port number of the binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="port">The port number.</param>
        /// <returns>The same <see cref="IPortBindingSettings"/> instance so that multiple calls can be chained.</returns>
        public static T SetPort<T>(this T binding, int port)
            where T : IPortBindingSettings
        {
            binding.Port = port;
            return binding;
        }

        /// <summary>
        /// Specifies the certificate store name of the binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="certificateStoreName">The certificate store name.</param>
        /// <returns>The same <see cref="ICertificateBindingSettings"/> instance so that multiple calls can be chained.</returns>
        public static T SetCertificateStoreName<T>(this T binding, string certificateStoreName)
            where T : ICertificateBindingSettings
        {
            binding.CertificateStoreName = certificateStoreName;
            return binding;
        }

        /// <summary>
        /// Specifies the certificate has of the binding.
        /// </summary>
        /// <param name="binding">The binding.</param>
        /// <param name="certificateHash">The certificate hash.</param>
        /// <returns>The same <see cref="ICertificateBindingSettings"/> instance so that multiple calls can be chained.</returns>
        public static T SetCertificateHash<T>(this T binding, byte[] certificateHash)
            where T : ICertificateBindingSettings
        {
            binding.CertificateHash = certificateHash;
            return binding;
        }
    }
}