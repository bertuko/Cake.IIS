namespace Cake.IIS.Settings.Bindings
{
    /// <summary>
    /// Class to represent and configure any type of IIS binding (secure or not).
    /// </summary>
    public class CustomBindingSettings : ISecureBindingSettings
    {
        #region Constructor (1)

            /// <summary>
            /// Creates new instance of <see cref="CustomBindingSettings"/>.
            /// </summary>
            /// <param name="bindingProtocol">Binding type.</param>
            public CustomBindingSettings(BindingProtocol bindingProtocol)
            {
                this.BindingProtocol = bindingProtocol;
            }

        #endregion





        #region Properties (7)
            /// <summary>
            /// Gets or sets IP Address
            /// </summary>
            public string IpAddress { get; set; }

            /// <summary>
            /// Gets or sets IP Port
            /// </summary>
            public int Port { get; set; }

            /// <summary>
            /// Gets or sets Host Name for binding
            /// </summary>
            public string HostName { get; set; }

            /// <inheritdoc />
            public byte[] CertificateHash { get; set; }

            /// <inheritdoc />
            public string CertificateStoreName { get; set; }

            /// <inheritdoc />
            public BindingProtocol BindingProtocol { get; private set; }

            /// <inheritdoc />
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