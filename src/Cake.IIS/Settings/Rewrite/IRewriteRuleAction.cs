using Microsoft.Web.Administration;

namespace Cake.IIS
{
    public interface IRewriteRuleAction
    {
        void FillXmlConfig(ConfigurationElement elem);
    }
}