namespace Cake.IIS.Settings.Bindings
{
    public sealed class HttpsBindingSettings : IBindingSecuritySettings
    {
        public HttpsBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.Https;
            this.HostName = "*";
            this.IpAddress = "*";
            this.Port = 443;
        }

        public string HostName { get; set; }

        public string IpAddress { get; set; }

        public int Port { get; set; }

        public BindingProtocol BindingProtocol { get; private set; }

        public string BindingInformation
        {
            get
            {
                return string.Format(@"{0}:{1}:{2}", IpAddress, Port, HostName);
            }
        }

        public byte[] CertificateHash { get; set; }

        public string CertificateStoreName { get; set; }
    }
}