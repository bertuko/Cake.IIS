using Microsoft.Web.Administration;

namespace Cake.IIS
{
    public class RewriteRuleNoneAction : IRewriteRuleAction
    {
        public void FillXmlConfig(ConfigurationElement elem)
        {
            elem["type"] = "None";
        }
    }
}