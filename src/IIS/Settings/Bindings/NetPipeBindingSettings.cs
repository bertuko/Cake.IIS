namespace Cake.IIS.Settings.Bindings
{
    public class NetPipeBindingSettings : BindingSettings
    {
        public NetPipeBindingSettings(string siteName) : base(siteName)
        {
            this.BindingProtocol = BindingProtocol.NetPipe;
            this.IpAddress = null;
            this.Port = 0;
            this.HostName = "*";
        }

        public override string BindingInformation
        {
            get { return string.Format("{0}", HostName); }
        }
    }
}