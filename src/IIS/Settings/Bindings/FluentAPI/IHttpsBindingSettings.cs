namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Fluent interface to configure https binding.
    /// </summary>
    public interface IHttpsBindingSettings
    {
        /// <inheritdoc cref="ICustomBindingSettings.Port"/>
        IHttpsBindingSettings Port(int port);

        /// <inheritdoc cref="ICustomBindingSettings.HostName"/>
        IHttpsBindingSettings HostName(string name);

        /// <inheritdoc cref="ICustomBindingSettings.IpAddress"/>
        IHttpsBindingSettings IpAddress(string ipAddress);

        /// <inheritdoc cref="ICustomBindingSettings.CertificateStoreName"/>
        IHttpsBindingSettings CertificateStoreName(string storeName);

        /// <inheritdoc cref="ICustomBindingSettings.CertificateHash"/>
        IHttpsBindingSettings CertificateHash(byte[] hashSet);

        /// <summary>
        /// Gets instance of <see cref="HttpsBindingSettings"/>.
        /// </summary>
        /// <returns>Fluently created instance of type <see cref="HttpsBindingSettings"/>.</returns>
        HttpsBindingSettings Instance { get; }
    }
}