using Microsoft.Web.Administration;

namespace Cake.IIS
{
    public class RewriteRuleAbortRequestAction : IRewriteRuleAction
    {
        public void FillXmlConfig(ConfigurationElement elem)
        {
            elem["type"] = "AbortRequest";
        }
    }
}