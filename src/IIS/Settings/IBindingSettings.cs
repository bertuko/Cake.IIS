namespace Cake.IIS.Settings
{
    public interface IBindingSettings
    {
        BindingProtocol BindingProtocol { get; }
        string BindingInformation { get; }
    }
}