using Microsoft.Web.Administration;

namespace Cake.IIS
{
    /// <summary>
    /// Action to ignore the request
    /// </summary>
    public class RewriteRuleNoneAction : IRewriteAction
    {
        public RewriteRuleNoneAction()
        {
            
        }

        /// <summary>
        /// Method to fill the XML configirations
        /// </summary>
        /// <param name="elem">XML configuration element</param>
        public void FillXmlConfig(ConfigurationElement elem)
        {
            elem["type"] = "None";
        }
    }
}