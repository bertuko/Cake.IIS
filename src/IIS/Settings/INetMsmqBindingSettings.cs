using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings
{
    /// <summary>
    /// Interface to configure net.msmq binding.
    /// </summary>
    public interface INetMsmqBindingSettings : 
        IBindingSettings, 
        IHostBindingSettings
    {
    }
}