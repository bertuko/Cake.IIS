#region Using Statements

using System;
using Cake.Core.IO;
    using Cake.IIS.Settings;
    using Cake.IIS.Settings.Bindings;
    using Cake.IIS.Settings.Bindings.FluentAPI;

#endregion



namespace Cake.IIS
{
    public abstract class SiteSettings : IDirectorySettings
    {
        #region Fields (1)
            private readonly CustomBindingSettings bindingSettings = new CustomBindingSettings(BindingProtocol.Http);
        #endregion

        #region Constructor (1)
            public SiteSettings()
                : base()
            {
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

            public IBindingSettings Binding { get; private set; }

            public ApplicationPoolSettings ApplicationPool { get; set; }

            public AuthenticationSettings Authentication { get; set; }

            public AuthorizationSettings Authorization { get; set; }

            public bool TraceFailedRequestsEnabled { get; set; }

            public string TraceFailedRequestsDirectory { get; set; }

            public long TraceFailedRequestsMaxLogFiles { get; set; }

            public bool ServerAutoStart { get; set; }

            public bool Overwrite { get; set; }

            /// <summary>
            /// Gets or sets IP Address
            /// </summary>
            [Obsolete("Use ChangeBinding or ChangeBindingTo method instead.")]
            public string IpAddress
            {
                get { return bindingSettings.IpAddress; }
                set { this.bindingSettings.IpAddress = value; }
            }

            /// <summary>
            /// Gets or sets IP Port
            /// </summary>
            [Obsolete("Use ChangeBinding or ChangeBindingTo method instead.")]
            public int Port
            {
                get { return bindingSettings.Port; }
                set { bindingSettings.Port = value; }
            }

            /// <summary>
            /// Gets or sets Host Name for binding
            /// </summary>
            [Obsolete("Use ChangeBinding or ChangeBindingTo method instead.")]
            public string HostName
            {
                get { return bindingSettings.HostName; }
                set { bindingSettings.HostName = value; }
            }

            /// <inheritdoc cref="ISecureBindingSettings.CertificateHash"/>
            [Obsolete("Use ChangeBinding or ChangeBindingTo method instead.")]
            public byte[] CertificateHash
            {
                get { return bindingSettings.CertificateHash; }
                set { bindingSettings.CertificateHash = value; }
            }

            /// <inheritdoc cref="ISecureBindingSettings.CertificateStoreName"/>
            [Obsolete("Use ChangeBinding or ChangeBindingTo method instead.")]
            public string CertificateStoreName
            {
                get { return bindingSettings.CertificateStoreName; }
                set { bindingSettings.CertificateStoreName = value; }
            }

            /// <inheritdoc cref="IBindingSettings.BindingProtocol"/>
            [Obsolete("Use ChangeBinding or ChangeBindingTo method instead.")]
            public BindingProtocol BindingProtocol
            {
                get { return bindingSettings.BindingProtocol; }
                set { bindingSettings.BindingProtocol = value; }
            }

        #endregion

        #region Methods (2)
            /// <summary>
            /// Changes site binding.
            /// </summary>
            /// <param name="binding">New default site binding.</param>
            public void ChangeBinding(IBindingSettings binding)
            {
                this.Binding = binding;
            }

            /// <summary>
            /// Changes site binding by fluent API.
            /// </summary>
            /// <returns>New instance of <see cref="IBindings"/> fluent interface to change and configure default site binding.</returns>
            public IBindings ChangeBindingTo()
            {
                return new IISBindings(ChangeBinding);
            }
        #endregion
    }
}