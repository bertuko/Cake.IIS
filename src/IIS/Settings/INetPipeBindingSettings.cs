using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings
{
    /// <summary>
    /// Interface to configure net.pipe binding.
    /// </summary>
    public interface INetPipeBindingSettings : 
        IBindingSettings, 
        IHostBindingSettings
    {
    }
}