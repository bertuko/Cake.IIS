using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings
{
    /// <summary>
    /// Interface to configure net.tcp binding.
    /// </summary>
    public interface INetTcpBindingSettings : 
        IHostBindingSettings, 
        IPortBindingSettings, 
        IBindingSettings
    {
    }
}