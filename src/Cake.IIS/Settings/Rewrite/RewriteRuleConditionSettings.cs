namespace Cake.IIS
{
    public class RewriteRuleConditionSettings
    {
        public string ConditionInput { get; set; }

        public string Pattern { get; set; }

        public bool NegatePattern { get; set; }

        public bool IgnoreCase { get; set; }
    }
}