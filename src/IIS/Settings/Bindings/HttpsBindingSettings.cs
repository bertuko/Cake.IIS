using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to configure https binding.
    /// </summary>
    public sealed class HttpsBindingSettings : BindingSettingsBase, IHttpsBindingSettings
    {
        /// <summary>
        /// Creates new predefined instance of <see cref="HttpsBindingSettings"/>.
        /// </summary>
        public HttpsBindingSettings() : base(BindingProtocol.Https)
        {
            this.HostName = "*";
            this.IpAddress = "*";
            this.Port = 443;
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