using System;
using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings.Bindings
{
    internal class IISBindings : IBindings
    {
        private readonly Action<IBindingSettings> _bindingCreationRelay;

        public IISBindings()
        {
        }

        public IISBindings(Action<IBindingSettings> bindingCreationRelay)
        {
            _bindingCreationRelay = bindingCreationRelay;
        }

        /// <inheritdoc />
        public IHttpBindingSettings Http()
        {
            var httpBindingSettings = new HttpBindingSettings();
            NotifyAboutCreation(httpBindingSettings);
            return httpBindingSettings;
        }

        /// <inheritdoc />
        public IHttpsBindingSettings Https()
        {
            var httpsBindingSettings = new HttpsBindingSettings();
            NotifyAboutCreation(httpsBindingSettings);
            return httpsBindingSettings;
        }

        /// <inheritdoc />
        public ICustomBindingSettings Ftp()
        {
            var ftpBindingSettings = new FtpBindingSettings();
            NotifyAboutCreation(ftpBindingSettings);
            return ftpBindingSettings;
        }

        /// <inheritdoc />
        public INetTcpBindingSettings NetTcp()
        {
            var netTcpBindingSettings = new NetTcpBindingSettings();
            NotifyAboutCreation(netTcpBindingSettings);
            return netTcpBindingSettings;
        }

        /// <inheritdoc />
        public INetPipeBindingSettings NetPipe()
        {
            var netPipeBindingSettings = new NetPipeBindingSettings();
            NotifyAboutCreation(netPipeBindingSettings);
            return netPipeBindingSettings;
        }

        /// <inheritdoc />
        public INetMsmqBindingSettings NetMsmq()
        {
            var netMsmqBindingSettings = new NetMsmqBindingSettings();
            NotifyAboutCreation(netMsmqBindingSettings);
            return netMsmqBindingSettings;
        }

        /// <inheritdoc />
        public IMsmqFormatNameBindingSettings MsmqFormatName()
        {
            var msmqFormatNameBindingSettings = new MsmqFormatNameBindingSettings();
            NotifyAboutCreation(msmqFormatNameBindingSettings);
            return msmqFormatNameBindingSettings;
        }

        /// <inheritdoc />
        public ICustomBindingSettings CustomBinding(BindingProtocol protocol)
        {
            var customBindingSettings = new CustomBindingSettings(protocol);
            NotifyAboutCreation(customBindingSettings);
            return customBindingSettings;
        }


        private void NotifyAboutCreation(IBindingSettings bindingSettings)
        {
            var relay = _bindingCreationRelay;
            if (relay != null)
            {
                relay(bindingSettings);
            }
        }
    }
}