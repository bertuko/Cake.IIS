using Microsoft.Web.Administration;

namespace Cake.IIS
{
    /// <summary>
    /// Action to do a custom response
    /// </summary>
    public class RewriteRuleCustomResponseAction : IRewriteAction
    {
        public RewriteRuleCustomResponseAction()
        {
            
        }

        /// <summary>
        /// The Custom Response status code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// The Custom Response substatus code
        /// </summary>
        public int? SubStatusCode { get; set; }

        /// <summary>
        /// The Custom Response Reason header
        /// </summary>
        public string StatusReason { get; set; }

        /// <summary>
        /// The Custom Response description
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// Method to fill the XML configirations
        /// </summary>
        /// <param name="elem">XML configuration element</param>
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