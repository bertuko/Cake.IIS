using Cake.IIS.Settings.Bindings;

namespace Cake.IIS.Settings
{
    public static class IISBindings
    {
        /// <summary>
        /// Creates http binding (port: 80)
        /// </summary>
        public static IHttpBindingSettings Http()
        {
            return new HttpBindingSettings();
        }

        /// <summary>
        /// Creates https binding (port: 443)
        /// </summary>
        public static IHttpsBindingSettings Https()
        {
            return new HttpsBindingSettings();
        }

        /// <summary>
        /// Creates ftp binding (port: 21)
        /// </summary>
        public static IFtpBindingSettings Ftp()
        {
            return new FtpBindingSettings();
        }

        /// <summary>
        /// Creates net.tcp binding (port: 808)
        /// </summary>
        public static INetTcpBindingSettings NetTcp()
        {
            return new NetTcpBindingSettings();
        }

        /// <summary>
        /// Creates net.pipe binding
        /// </summary>
        public static INetPipeBindingSettings NetPipe()
        {
            return new NetPipeBindingSettings();
        }

        /// <summary>
        /// Creates net.msmq binding.
        /// </summary>
        public static INetMsmqBindingSettings NetMsmq()
        {
            return new NetMsmqBindingSettings();
        }

        /// <summary>
        /// Creates msmq.formatname binding
        /// </summary>
        public static IMsmqFormatNameBindingSettings MsmqFormatName()
        {
            return new MsmqFormatNameBindingSettings();
        }

        /// <summary>
        /// Creates custom binding.
        /// </summary>
        /// <param name="protocol">Binding protocol.</param>
        public static ICustomBindingSettings CustomBinding(BindingProtocol protocol)
        {
            return new CustomBindingSettings(protocol);
        }
    }
}