using Microsoft.Web.Administration;

namespace Cake.IIS
{
    public class RewriteRuleRewriteAction : IRewriteRuleAction
    {
        public string Url { get; set; }

        public void FillXmlConfig(ConfigurationElement elem)
        {
            elem["type"] = "Rewrite";
            elem["url"] = Url;
        }
    }
}