namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to configure any type of IIS binding (secure or not).
    /// </summary>
    public sealed class CustomBindingSettings : BindingSettingsBase, ICustomBindingSettings
    {
        /// <summary>
        /// Creates new instance of <see cref="CustomBindingSettings"/>.
        /// </summary>
        /// <param name="bindingProtocol">Binding type.</param>
        public CustomBindingSettings(BindingProtocol bindingProtocol) : base(bindingProtocol)
        {
        }
    }
}