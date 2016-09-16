namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Fluent interface to configure any type of binding.
    /// </summary>
    public interface ICustomBindingSettings
    {
        /// <summary>
        /// Sets port number.
        /// </summary>
        /// <param name="port">The port number.</param>
        ICustomBindingSettings Port(int port);

        /// <summary>
        /// Sets host name.
        /// </summary>
        /// <param name="name">The host name.</param>
        ICustomBindingSettings HostName(string name);

        /// <summary>
        /// Sets IP Address
        /// </summary>
        /// <param name="ipAddress">The IP Address.</param>
        ICustomBindingSettings IpAddress(string ipAddress);

        /// <summary>
        /// Sets the name of Certificate Store
        /// </summary>
        /// <param name="storeName">The name of certificate store.</param>
        /// <returns></returns>
        ICustomBindingSettings CertificateStoreName(string storeName);

        /// <summary>
        /// Sets certificate hash.
        /// </summary>
        /// <param name="hashSet">The certificate hash.</param>
        ICustomBindingSettings CertificateHash(byte[] hashSet);

        /// <summary>
        /// Gets instance of <see cref="CustomBindingSettings"/>.
        /// </summary>
        /// <returns>Fluently created instance of type <see cref="CustomBindingSettings"/>.</returns>
        CustomBindingSettings Instance { get; }
    }
}