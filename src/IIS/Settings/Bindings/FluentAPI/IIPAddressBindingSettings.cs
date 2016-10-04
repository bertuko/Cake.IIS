namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Binding settings with IP Address.
    /// </summary>
    public interface IIpAddressBindingSettings
    {
        /// <summary>
        /// Gets or sets IP Address
        /// </summary>
        string IpAddress { get; set; }
    }
}