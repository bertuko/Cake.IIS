namespace Cake.IIS.Settings.Bindings
{
    public sealed class HttpBindingSettings : IBindingSettings
    {
        public HttpBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.Http;
            this.HostName = "*";
            this.IpAddress = "*";
            this.Port = 80;
        }

        public string HostName { get; set; }

        public int Port { get; set; }

        public string IpAddress { get; set; }

        public BindingProtocol BindingProtocol { get; private set; }

        public string BindingInformation
        {
            get
            {
                return string.Format(@"{0}:{1}:{2}", IpAddress, Port, HostName);
            }
        }
    }
}