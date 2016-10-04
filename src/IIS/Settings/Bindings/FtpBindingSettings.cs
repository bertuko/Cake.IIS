namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to configure ftp binding.
    /// </summary>
    public sealed class FtpBindingSettings : BindingSettingsBase, IFtpBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="FtpBindingSettings"/>.
        /// </summary>
        public FtpBindingSettings() : base(BindingProtocol.Ftp)
        {
            Port = 21;
        }
    }
}