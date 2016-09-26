using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to configure http binding.
    /// </summary>
    public sealed class HttpBindingSettings : BindingSettingsBase, IHttpBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="HttpBindingSettings"/>.
        /// </summary>
        public HttpBindingSettings() : base(BindingProtocol.Http)
        {
            this.HostName = "*";
            this.IpAddress = "*";
            this.Port = 80;
        }

        /// <inheritdoc cref="IBindingSettings.BindingInformation"/>
        public override string BindingInformation
        {
            get
            {
                return string.Format(@"{0}:{1}:{2}", IpAddress, Port, HostName);
            }
        }
    }
}