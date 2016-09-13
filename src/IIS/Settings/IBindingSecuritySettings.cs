namespace Cake.IIS.Settings
{
    public interface IBindingSecuritySettings : IBindingSettings
    {
        byte[] CertificateHash { get; set; }
        string CertificateStoreName { get; set; }
    }
}