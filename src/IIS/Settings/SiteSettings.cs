#region Using Statements
    using Cake.Core.IO;
    using Cake.IIS.Settings;
    using Cake.IIS.Settings.Bindings;
    using Cake.IIS.Settings.Bindings.FluentAPI;

#endregion



namespace Cake.IIS
{
    public abstract class SiteSettings : IDirectorySettings
    {
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