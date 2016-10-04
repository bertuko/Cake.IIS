using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings
{
    /// <summary>
    /// Interface to configure https binding.
    /// </summary>
    public interface IHttpsBindingSettings : 
        IHttpBindingSettings, 
        ICertificateBindingSettings
    {
    }
}