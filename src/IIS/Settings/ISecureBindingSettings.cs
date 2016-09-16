namespace Cake.IIS.Settings
{
    /// <summary>
    /// Binding settings for secure IIS site.
    /// </summary>
    public interface ISecureBindingSettings : IBindingSettings
    {
        /// <summary>
        /// Gets or sets hash for specific certificate.
        /// </summary>
        byte[] CertificateHash { get; set; }

        /// <summary>
        /// Gets or sets the name of Certificate Store
        /// </summary>
        string CertificateStoreName { get; set; }
    }
}