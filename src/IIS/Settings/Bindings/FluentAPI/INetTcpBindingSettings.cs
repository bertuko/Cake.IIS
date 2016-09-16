namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Fluent interface to configure net.tcp binding.
    /// </summary>
    public interface INetTcpBindingSettings
    {
        /// <inheritdoc cref="ICustomBindingSettings.Port"/>
        INetTcpBindingSettings Port(int port);

        /// <inheritdoc cref="ICustomBindingSettings.HostName"/>
        INetTcpBindingSettings HostName(string name);

        /// <summary>
        /// Gets instance of <see cref="NetTcpBindingSettings"/>.
        /// </summary>
        /// <returns>Fluently created instance of type <see cref="NetTcpBindingSettings"/>.</returns>
        NetTcpBindingSettings Instance { get; }
    }
}