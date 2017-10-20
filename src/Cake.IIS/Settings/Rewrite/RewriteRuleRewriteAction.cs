using Microsoft.Web.Administration;

namespace Cake.IIS
{
    /// <summary>
    /// Actin to rewrite the request URL
    /// </summary>
    public class RewriteRuleRewriteAction : IRewriteAction
    {
        public RewriteRuleRewriteAction()
        {
            
        }

        /// <summary>
        /// The real URL to call
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Method to fill the XML configirations
        /// </summary>
        /// <param name="elem">XML configuration element</param>
        public void FillXmlConfig(ConfigurationElement elem)
        {
            elem["type"] = "Rewrite";
            elem["url"] = Url;
        }
    }
}