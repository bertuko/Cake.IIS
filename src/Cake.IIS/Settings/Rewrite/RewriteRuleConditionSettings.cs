namespace Cake.IIS
{
    /// <summary>
    /// Rewrite conditions settings
    /// </summary>
    public class RewriteRuleConditionSettings
    {
        public RewriteRuleConditionSettings()
        {
            
        }

        /// <summary>
        /// The condition input parameter 
        /// </summary>
        public string ConditionInput { get; set; }

        /// <summary>
        /// The pattern to compare to ConditionInput
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Invert the pattern behavior
        /// </summary>
        public bool NegatePattern { get; set; }

        /// <summary>
        /// Ignore the case in comparation
        /// </summary>
        public bool IgnoreCase { get; set; }
    }
}