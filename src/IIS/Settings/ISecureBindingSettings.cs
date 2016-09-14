namespace Cake.IIS.Settings
{
    public interface ISecureBindingSettings : IBindingSettings
    {
        byte[] CertificateHash { get; set; }
        string CertificateStoreName { get; set; }
    }
}