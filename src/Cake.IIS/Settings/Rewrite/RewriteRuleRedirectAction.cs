using Microsoft.Web.Administration;

namespace Cake.IIS
{
    public class RewriteRuleRedirectAction : IRewriteRuleAction
    {
        public string Url { get; set; }

        public RewriteRuleRedirectType RedirectType { get; set; }

        public void FillXmlConfig(ConfigurationElement elem)
        {
            elem["type"] = "Redirect";
            elem["url"] = Url;
            elem["redirectType"] = RedirectType;
        }
    }
}