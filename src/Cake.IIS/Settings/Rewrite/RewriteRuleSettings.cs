using System.Collections.Generic;

namespace Cake.IIS
{
    public class RewriteRuleSettings
    {
        #region Constructor
        public RewriteRuleSettings()
        {
        }
        #endregion


        #region Properties
        public string Name { get; set; }

        public RewritePatternSintax PatternSintax { get; set; }

        public string Pattern { get; set; }

        public bool NegatePattern { get; set; }

        public bool IgnoreCase { get; set; }

        public bool StopProcessing { get; set; }

        public IRewriteRuleAction Action { get; set; }

        public RewriteConditionsGrouping ConditionsGrouping { get; set; }

        public IEnumerable<RewriteRuleConditionSettings> Conditions { get; set; }
        #endregion
    }
}