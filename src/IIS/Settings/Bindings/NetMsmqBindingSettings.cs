namespace Cake.IIS.Settings.Bindings
{
    public class NetMsmqBindingSettings : BindingSettings
    {
        public NetMsmqBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.NetMsmq;
            this.IpAddress = null;
            this.Port = 0;
            this.HostName = "localhost";
        }

        public override string BindingInformation
        {
            get { return string.Format("{0}", HostName); }
        }
    }
}