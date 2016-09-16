namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to represent and configure msmq.formatname binding.
    /// </summary>
    public sealed class MsmqFormatNameBindingSettings : IBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="MsmqFormatNameBindingSettings"/>.
        /// </summary>
        public MsmqFormatNameBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.MsmqFormatName;
            this.HostName = "localhost";
        }

        /// <summary>
        /// Gets or sets Host Name for binding.
        /// </summary>
        /// <returns>The Host Name of binding. Default: <c>localhost</c>.</returns>
        public string HostName { get; set; }

        /// <inheritdoc />
        public BindingProtocol BindingProtocol { get; private set; }

        /// <inheritdoc />
        public string BindingInformation
        {
            get { return string.Format("{0}", HostName); }
        }
    }
}