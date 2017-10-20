using System.Collections.Generic;

namespace Cake.IIS
{
    /// <summary>
    /// Rewrite rule settings
    /// </summary>
    public class RewriteRuleSettings
    {
        #region Constructor
        public RewriteRuleSettings()
        {
        }
        #endregion


        #region Properties
        /// <summary>
        /// Rule name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pattern comparison type
        /// </summary>
        public RewritePatternSintax PatternSintax { get; set; }

        /// <summary>
        /// The pattern to validate the URL
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Invert the pattern behavior
        /// </summary>
        public bool NegatePattern { get; set; }

        /// <summary>
        /// Ignore the URL case
        /// </summary>
        public bool IgnoreCase { get; set; }

        /// <summary>
        /// Stop processing other rules if this rule was succeeded
        /// </summary>
        public bool StopProcessing { get; set; }

        /// <summary>
        /// The action to be executed if this rule was succeeded
        /// </summary>
        public IRewriteAction Action { get; set; }

        /// <summary>
        /// Choose conditions behavior between AND or OR
        /// </summary>
        public RewriteConditionsGrouping ConditionsGrouping { get; set; }

        /// <summary>
        /// Conditions collection for this rule
        /// </summary>
        public IEnumerable<RewriteRuleConditionSettings> Conditions { get; set; }
        #endregion
    }
}