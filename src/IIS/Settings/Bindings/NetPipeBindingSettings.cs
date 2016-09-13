namespace Cake.IIS.Settings.Bindings
{
    public sealed class NetPipeBindingSettings : IBindingSettings
    {
        public NetPipeBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.NetPipe;
            this.HostName = "*";
        }

        public string HostName { get; set; }

        public BindingProtocol BindingProtocol { get; private set; }

        public string BindingInformation
        {
            get { return string.Format("{0}", HostName); }
        }
    }
}