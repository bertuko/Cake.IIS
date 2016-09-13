namespace Cake.IIS.Settings.Bindings
{
    public sealed class NetTcpBindingSettings : IBindingSettings
    {
        public NetTcpBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.NetTcp;
            this.Port = 808;
            this.HostName = "*";
        }

        public string HostName { get; set; }

        public int Port { get; set; }

        public BindingProtocol BindingProtocol { get; private set; }

        public string BindingInformation
        {
            get { return string.Format("{0}:{1}", Port, HostName); }
        }
    }
}