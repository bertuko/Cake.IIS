using Cake.IIS.Settings.Bindings.FluentAPI;

namespace Cake.IIS.Settings
{
    /// <summary>
    /// Interface to configure msmq.formatname binding.
    /// </summary>
    public interface IMsmqFormatNameBindingSettings : 
        IBindingSettings, 
        IHostBindingSettings
    {
    }
}