namespace Cake.IIS.Settings.Bindings
{
    public interface IBindings
    {
        /// <summary>
        /// Gets http binding (port: 80)
        /// </summary>
        /// <value>New instance of <see cref="HttpBindingSettings"/></value>
        HttpBindingSettings Http { get; }

        /// <summary>
        /// Gets https binding (port: 443)
        /// </summary>
        HttpsBindingSettings Https { get; }

        /// <summary>
        /// Gets ftp binding (port: 21)
        /// </summary>
        CustomBindingSettings Ftp { get; }

        /// <summary>
        /// Gets ftp (FTP-SSL/FTP-Secure) binding (port: 21)
        /// </summary>
        CustomBindingSettings Ftps { get; }

        /// <summary>
        /// Gets net.tcp binding (port: 808)
        /// </summary>
        NetTcpBindingSettings NetTcp { get; }

        /// <summary>
        /// Gets net.pipe binding
        /// </summary>
        NetPipeBindingSettings NetPipe { get; }

        /// <summary>
        /// Gets net.msmq binding
        /// </summary>
        NetMsmqBindingSettings NetMsmq { get; }

        /// <summary>
        /// Gets msmq.formatname binding
        /// </summary>
        MsmqFormatNameBindingSettings MsmqFormatName { get; }
    }
}