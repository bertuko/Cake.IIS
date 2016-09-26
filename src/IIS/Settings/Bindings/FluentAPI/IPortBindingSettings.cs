namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Binding Settings with port number.
    /// </summary>
    public interface IPortBindingSettings
    {
        /// <summary>
        /// Gets or sets IP Port
        /// </summary>
        int Port { get; set; }
    }
}