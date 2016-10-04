using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings
{
    /// <summary>
    /// Interface to configure http binding.
    /// </summary>
    public interface IHttpBindingSettings : 
        IBindingSettings, 
        IHostBindingSettings, 
        IIpAddressBindingSettings, 
        IPortBindingSettings
    {
    }
}