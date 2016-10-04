namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Binding settings with host name.
    /// </summary>
    public interface IHostBindingSettings
    {
        /// <summary>
        /// Gets or sets Host Name for binding
        /// </summary>
        string HostName { get; set; }
    }
}