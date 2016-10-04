namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    /// <summary>
    /// Binding settings for IIS site.
    /// </summary>
    public interface IBindingSettings
    {
        /// <summary>
        /// Gets IIS binding type.
        /// </summary>>
        /// <returns>
        /// Returns <see cref="BindingProtocol"/> which will be used to determine IIS binding type.
        /// </returns>
        BindingProtocol BindingProtocol { get; }

        /// <summary>
        /// Gets IIS binding information
        /// </summary>
        /// <returns>
        /// Returns details of binding properties required to set up specific binding type.
        /// </returns>
        string BindingInformation { get; }
    }
}