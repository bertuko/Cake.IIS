using Microsoft.Web.Administration;

namespace Cake.IIS
{
    /// <summary>
    /// Action to redirect the client to anhother page
    /// </summary>
    public class RewriteRuleRedirectAction : IRewriteAction
    {
        public RewriteRuleRedirectAction()
        {
            
        }

        /// <summary>
        /// The URL to redirect the client
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The rediretion type
        /// </summary>
        public RewriteRuleRedirectType RedirectType { get; set; }

        /// <summary>
        /// Method to fill the XML configirations
        /// </summary>
        /// <param name="elem">XML configuration element</param>
        public void FillXmlConfig(ConfigurationElement elem)
        {
            elem["type"] = "Redirect";
            elem["url"] = Url;
            elem["redirectType"] = RedirectType.ToString();
        }
    }
}