namespace Cake.IIS.Settings.Bindings
{
    public class NetTcpBindingSettings : BindingSettings
    {
        public NetTcpBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.NetTcp;
            this.IpAddress = null;
            this.Port = 808;
            this.HostName = "*";
        }

        public override string BindingInformation
        {
            get { return string.Format("{0}:{1}", Port, HostName); }
        }
    }
}