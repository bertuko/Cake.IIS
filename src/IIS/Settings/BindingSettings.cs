namespace Cake.IIS
{
    public class BindingSettings
    {
        #region Constructor (2)

            internal BindingSettings()
            {
            }

            public BindingSettings(string siteName)
            {
                this.Name            = siteName;
                this.BindingProtocol = BindingProtocol.Http;

                this.IpAddress       = "*";
                this.Port            = 80;
                this.HostName        = "*";
            }
        #endregion





        #region Properties (6)
            public string Name { get; set; }



            public string IpAddress { get; set; }

            public int Port { get; set; }

            public string HostName { get; set; }

            public byte[] CertificateHash { get; set; }

            public string CertificateStoreName { get; set; }

            public BindingProtocol BindingProtocol { get; set; }

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