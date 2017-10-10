namespace Cake.IIS
{
    /// <summary>
    /// Redirects types accepted by IIS
    /// </summary>
    public enum RewriteRuleRedirectType
    {
        /// <summary>
        /// Respond a 301 to client
        /// </summary>
        Permanent,
        /// <summary>
        /// Respond a 302 to client
        /// </summary>
        Found,
        /// <summary>
        /// Respond a 303 to client
        /// </summary>
        SeeOther,
        /// <summary>
        /// Respond a 307 to client
        /// </summary>
        Temporary
    }
}