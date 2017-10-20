namespace Cake.IIS
{
    /// <summary>
    /// Options to change the behavior of the conditions
    /// </summary>
    public enum RewriteConditionsGrouping
    {
        /// <summary>
        /// If one condition is succeeded, all the rule are succeeded
        /// </summary>
        MatchAny,
        /// <summary>
        /// If all condition is succeeded, the rule are succeeded
        /// </summary>
        MatchAll
    }
}