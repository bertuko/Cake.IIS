namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to represent and configure ftp binding.
    /// </summary>
    public class FtpBindingSettings : CustomBindingSettings
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