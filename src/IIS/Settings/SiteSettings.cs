#region Using Statements

    using System;
    using Cake.Core.IO;
    using Cake.IIS.Settings;
    using Cake.IIS.Settings.Bindings.FluentAPI;

#endregion



namespace Cake.IIS
{
    public abstract class SiteSettings : 
        ICustomBindingSettings, 
        IDirectorySettings
    {
        #region Constructor (1)
            public SiteSettings()
            {
                this.BindingProtocol = BindingProtocol.Http;
                this.ServerAutoStart = true;
                this.Overwrite = false;
                this.ApplicationPool = new ApplicationPoolSettings();
            }
        #endregion





        #region Properties (11)
            public string ComputerName { get; set; }

            public DirectoryPath WorkingDirectory { get; set; }

            public DirectoryPath PhysicalDirectory { get; set; }

            public string Name { get; set; }

            public IBindingSettings Binding { get; set; }

            public ApplicationPoolSettings ApplicationPool { get; set; }

            public AuthenticationSettings Authentication { get; set; }

            public AuthorizationSettings Authorization { get; set; }

            public bool TraceFailedRequestsEnabled { get; set; }

            public string TraceFailedRequestsDirectory { get; set; }

            public long TraceFailedRequestsMaxLogFiles { get; set; }

            public bool ServerAutoStart { get; set; }

            public bool Overwrite { get; set; }

            /// <inheritdoc />
            [Obsolete("Use Binding property instead.")]
            public string IpAddress { get; set; }

            /// <inheritdoc />
            [Obsolete("Use Binding property instead.")]
            public int Port { get; set; }

            /// <inheritdoc />
            [Obsolete("Use Binding property instead.")]
            public string HostName { get; set; }

            /// <inheritdoc />
            [Obsolete("Use Binding property instead.")]
            public byte[] CertificateHash { get; set; }

            /// <inheritdoc />
            [Obsolete("Use Binding property instead.")]
            public string CertificateStoreName { get; set; }

            /// <inheritdoc />
            [Obsolete("Use Binding property instead.")]
            public new BindingProtocol BindingProtocol { get; set; }

            /// <inheritdoc />
            [Obsolete("Use Binding property instead.")]
            public string BindingInformation
            {
                get
                {
                    return string.Format(@"{0}:{1}:{2}", IpAddress, Port, HostName);
                }
            }
        #endregion
    }
}