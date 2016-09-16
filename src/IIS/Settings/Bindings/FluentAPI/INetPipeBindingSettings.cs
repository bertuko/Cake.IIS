namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Fluent interface to configure net.pipe binding.
    /// </summary>
    public interface INetPipeBindingSettings
    {
        /// <inheritdoc cref="ICustomBindingSettings.HostName"/>
        INetPipeBindingSettings HostName(string name);

        /// <summary>
        /// Gets instance of <see cref="NetPipeBindingSettings"/>.
        /// </summary>
        /// <returns>Fluently created instance of type <see cref="NetPipeBindingSettings"/>.</returns>
        NetPipeBindingSettings Instance { get; }
    }
}