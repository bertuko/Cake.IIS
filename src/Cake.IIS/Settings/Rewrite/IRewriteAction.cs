using Microsoft.Web.Administration;

namespace Cake.IIS
{
    /// <summary>
    /// Interface for the rewrite actions
    /// </summary>
    public interface IRewriteAction
    {
        /// <summary>
        /// Method to fill the XML configirations
        /// </summary>
        /// <param name="elem">XML configuration element</param>
        void FillXmlConfig(ConfigurationElement elem);
    }
}