namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to configure msmq.formatname binding.
    /// </summary>
    public sealed class MsmqFormatNameBindingSettings : BindingSettingsBase, IMsmqFormatNameBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="MsmqFormatNameBindingSettings"/>.
        /// </summary>
        public MsmqFormatNameBindingSettings() : base(BindingProtocol.MsmqFormatName)
        {
            HostName = "localhost";
        }
    }
}