namespace Cake.IIS.Settings.Bindings
{
    public class CustomBindingSettings : ISecureBindingSettings
    {
        #region Constructor (1)

            public CustomBindingSettings(BindingProtocol bindingProtocol)
            {
                this.BindingProtocol = bindingProtocol;
            }

        #endregion





        #region Properties (7)
            public string IpAddress { get; set; }

            public int Port { get; set; }

            public string HostName { get; set; }

            public byte[] CertificateHash { get; set; }

            public string CertificateStoreName { get; set; }

            public BindingProtocol BindingProtocol { get; private set; }

            public virtual string BindingInformation
            {
                get
                {
                    return string.Format(@"{0}:{1}:{2}", IpAddress, Port, HostName);
                }
            }
        #endregion
    }
}