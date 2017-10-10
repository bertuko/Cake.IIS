namespace Cake.IIS
{
    /// <summary>
    /// The pattern sintax to be used
    /// </summary>
    public enum RewritePatternSintax
    {
        /// <summary>
        /// Use regular expression
        /// </summary>
        ECMAScript,
        /// <summary>
        /// Use a wildcard (*)
        /// </summary>
        Wildcard,
        /// <summary>
        /// Compare the exact sentence
        /// </summary>
        ExactMatch
    }
}