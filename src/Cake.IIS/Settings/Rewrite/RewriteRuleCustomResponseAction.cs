using Microsoft.Web.Administration;

namespace Cake.IIS
{
    public class RewriteRuleCustomResponseAction : IRewriteRuleAction
    {
        public int StatusCode { get; set; }

        public int? SubStatusCode { get; set; }

        public string StatusReason { get; set; }

        public string StatusDescription { get; set; }

        public void FillXmlConfig(ConfigurationElement elem)
        {
            elem["type"] = "CustomResponse";
            elem["statusCode"] = StatusCode;

            if (SubStatusCode.HasValue)
                elem["subStatusCode"] = SubStatusCode.Value;

            elem["statusReason"] = StatusReason;
            elem["statusDescription"] = StatusDescription;
        }
    }
}