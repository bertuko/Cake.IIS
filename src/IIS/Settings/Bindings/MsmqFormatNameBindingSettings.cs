namespace Cake.IIS.Settings.Bindings
{
    public sealed class MsmqFormatNameBindingSettings : IBindingSettings
    {
        public MsmqFormatNameBindingSettings()
        {
            this.BindingProtocol = BindingProtocol.MsmqFormatName;
            this.HostName = "localhost";
        }

        public string HostName { get; set; }

        public BindingProtocol BindingProtocol { get; private set; }

        public string BindingInformation
        {
            get { return string.Format("{0}", HostName); }
        }
    }
}