namespace Cake.IIS.Settings.Bindings
{
    public class MsmqFormatNameBindingSettings : BindingSettings
    {
        public MsmqFormatNameBindingSettings(string siteName) : base(siteName)
        {
            this.BindingProtocol = BindingProtocol.MsmqFormatName;
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