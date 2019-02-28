#region Using Statements
using System.Collections.Generic;
using Cake.Core.IO;
#endregion



namespace Cake.IIS
{
    public abstract class SiteSettings : IDirectorySettings
    {
        #region Constructor
        public SiteSettings()
            : base()
        {
            this.Bindings = new BindingSettings[] { IISBindings.Http };
            this.ServerAutoStart = true;
            this.Overwrite = false;
            this.ApplicationPool = new ApplicationPoolSettings();
        }
        #endregion





        #region Properties
        public string Name { get; set; }

        public string ComputerName { get; set; }

        public DirectoryPath WorkingDirectory { get; set; }

        public DirectoryPath PhysicalDirectory { get; set; }

        public IEnumerable<BindingSettings> Bindings { get; set; }

        public string AlternateEnabledProtocols { get; set; }

        public ApplicationPoolSettings ApplicationPool { get; set; }

        public AuthenticationSettings Authentication { get; set; }

        public AuthorizationSettings Authorization { get; set; }



        public bool TraceFailedRequestsEnabled { get; set; }

        public string TraceFailedRequestsDirectory { get; set; }

        public long TraceFailedRequestsMaxLogFiles { get; set; }


        
        public bool ServerAutoStart { get; set; }

        public bool Overwrite { get; set; }
        #endregion
    }
}