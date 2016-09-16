namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Fluent interface to configure http binding.
    /// </summary>
    public interface IHttpBindingSettings
    {
        /// <inheritdoc cref="ICustomBindingSettings.Port"/>
        IHttpBindingSettings Port(int port);

        /// <inheritdoc cref="ICustomBindingSettings.HostName"/>
        IHttpBindingSettings HostName(string name);

        /// <inheritdoc cref="ICustomBindingSettings.IpAddress"/>
        IHttpBindingSettings IpAddress(string ipAddress);

        /// <summary>
        /// Gets instance of <see cref="HttpBindingSettings"/>.
        /// </summary>
        /// <returns>Fluently created instance of type <see cref="HttpBindingSettings"/>.</returns>
        HttpBindingSettings Instance { get; }
    }
}