using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings
{
    /// <summary>
    /// Interface to configure any type of binding.
    /// </summary>
    public interface ICustomBindingSettings : 
        IBindingSettings, 
        ICertificateBindingSettings, 
        IHostBindingSettings, 
        IIpAddressBindingSettings, 
        IPortBindingSettings
    {
    }
}