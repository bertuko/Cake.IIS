namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Fluent interface to configure any type of binding.
    /// </summary>
    public interface INetMsmqBindingSettings
    {
        /// <inheritdoc cref="ICustomBindingSettings.HostName"/>
        INetMsmqBindingSettings HostName(string name);

        /// <summary>
        /// Gets instance of <see cref="NetMsmqBindingSettings"/>.
        /// </summary>
        /// <returns>Fluently created instance of type <see cref="NetMsmqBindingSettings"/>.</returns>
        NetMsmqBindingSettings Instance { get; }
    }
}