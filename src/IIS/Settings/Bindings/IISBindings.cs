namespace Cake.IIS.Settings.Bindings
{
    internal class IISBindings : IBindings
    {
        /// <summary>
        /// Gets http binding (port: 80)
        /// </summary>
        /// <value>New instance of <see cref="HttpBindingSettings"/></value>
        public HttpBindingSettings Http
        {
            get { return new HttpBindingSettings(); }
        }

        /// <summary>
        /// Gets https binding (port: 443)
        /// </summary>
        public HttpsBindingSettings Https
        {
            get { return new HttpsBindingSettings(); }
        }

        /// <summary>
        /// Gets ftp binding (port: 21)
        /// </summary>
        public CustomBindingSettings Ftp
        {
            get
            {
                return new CustomBindingSettings(BindingProtocol.Ftp)
                {
                    Port = 21,
                };
            }
        }

        /// <summary>
        /// Gets ftp (FTP-SSL/FTP-Secure) binding (port: 21)
        /// </summary>
        public CustomBindingSettings Ftps
        {
            get
            {
                return new CustomBindingSettings(BindingProtocol.Ftp)
                {
                    Port = 21
                };
            }
        }

        /// <summary>
        /// Gets net.tcp binding (port: 808)
        /// </summary>
        public NetTcpBindingSettings NetTcp
        {
            get { return new NetTcpBindingSettings(); }
        }

        /// <summary>
        /// Gets net.pipe binding
        /// </summary>
        public NetPipeBindingSettings NetPipe
        {
            get { return new NetPipeBindingSettings(); }
        }

        /// <summary>
        /// Gets net.msmq binding
        /// </summary>
        public NetMsmqBindingSettings NetMsmq
        {
            get { return new NetMsmqBindingSettings(); }
        }

        /// <summary>
        /// Gets msmq.formatname binding
        /// </summary>
        public MsmqFormatNameBindingSettings MsmqFormatName
        {
            get { return new MsmqFormatNameBindingSettings(); }
        }
    }
}