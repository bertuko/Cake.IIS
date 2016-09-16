namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Fluent interface to configure msmq.formatname binding.
    /// </summary>
    public interface IMsmqFormatNameBindingSettings
    {
        /// <inheritdoc cref="ICustomBindingSettings.HostName"/>
        IMsmqFormatNameBindingSettings HostName(string name);

        /// <summary>
        /// Gets instance of <see cref="MsmqFormatNameBindingSettings"/>.
        /// </summary>
        /// <returns>Fluently created instance of type <see cref="MsmqFormatNameBindingSettings"/>.</returns>
        MsmqFormatNameBindingSettings Instance { get; }
    }
}