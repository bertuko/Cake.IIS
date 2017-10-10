using Microsoft.Web.Administration;

namespace Cake.IIS
{
    /// <summary>
    /// Action to abort the request
    /// </summary>
    public class RewriteRuleAbortRequestAction : IRewriteAction
    {
        public RewriteRuleAbortRequestAction()
        {
            
        }

        /// <summary>
        /// Method to fill the XML configirations
        /// </summary>
        /// <param name="elem">XML configuration element</param>
        public void FillXmlConfig(ConfigurationElement elem)
        {
            elem["type"] = "AbortRequest";
        }
    }
}