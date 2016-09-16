namespace Cake.IIS.Settings.Bindings.FluentAPI
{
    public interface IBindings
    {
        /// <summary>
        /// Creates http binding (port: 80)
        /// </summary>
        IHttpBindingSettings Http();

        /// <summary>
        /// Creates https binding (port: 443)
        /// </summary>
        IHttpsBindingSettings Https();

        /// <summary>
        /// Creates ftp binding (port: 21)
        /// </summary>
        ICustomBindingSettings Ftp();

        /// <summary>
        /// Creates net.tcp binding (port: 808)
        /// </summary>
        INetTcpBindingSettings NetTcp();

        /// <summary>
        /// Creates net.pipe binding
        /// </summary>
        INetPipeBindingSettings NetPipe();

        /// <summary>
        /// Creates net.msmq binding.
        /// </summary>
        INetMsmqBindingSettings NetMsmq();

        /// <summary>
        /// Creates msmq.formatname binding
        /// </summary>
        IMsmqFormatNameBindingSettings MsmqFormatName();

        /// <summary>
        /// Creates custom binding.
        /// </summary>
        /// <param name="protocol">Binding protocol.</param>
        ICustomBindingSettings CustomBinding(BindingProtocol protocol);
    }
}