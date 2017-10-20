#region Using Statements
using System;
using System.Linq;

using Microsoft.Web.Administration;

using Cake.Core;
using Cake.Core.Diagnostics;
#endregion



namespace Cake.IIS
{
    /// <summary>
    /// Class for managing rewrite rules
    /// </summary>
    public class RewriteManager : BaseManager
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RewriteManager" /> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="log">The log.</param>
        public RewriteManager(ICakeEnvironment environment, ICakeLog log)
                : base(environment, log)
        {

        }
        #endregion





        #region Methods
        /// <summary>
        /// Creates a new instance of the <see cref="RewriteManager" /> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="log">The log.</param>
        /// <param name="server">The <see cref="ServerManager" /> to connect to.</param>
        /// <returns>a new instance of the <see cref="RewriteManager" />.</returns>
        public static RewriteManager Using(ICakeEnvironment environment, ICakeLog log, ServerManager server)
        {
            RewriteManager manager = new RewriteManager(environment, log);

            manager.SetServer(server);

            return manager;
        }


        private ConfigurationElementCollection GetGlobalRewriteRules()
        {
            Configuration config = _Server.GetApplicationHostConfiguration();
            ConfigurationSection section = config.GetSection("system.webServer/rewrite/globalRules");

            return section.GetCollection();
        }



        /// <summary>
        /// Creates a rewrite rule
        /// </summary>
        /// <param name="settings">The settings of the rewrite rule to add</param>
        /// <returns>If the rewrite rule was added.</returns>
        public void CreateRule(RewriteRuleSettings settings)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            if (string.IsNullOrWhiteSpace(settings.Name))
                throw new ArgumentException($"{nameof(settings.Name)} cannot be null!");

            if (settings.Action == null)
                throw new ArgumentException($"{nameof(settings.Action)} cannot be null!");

            if (Exists(settings.Name))
            {
                _Log.Information($"Rewrite rule '{settings.Name}' already exists.");
                return;
            }

            var globalRules = GetGlobalRewriteRules();

            var rule = globalRules.CreateElement("rule");

            FillRule(settings, rule);

            if (settings.Conditions?.Any() == true)
                FillConditions(settings, rule);

            settings.Action.FillXmlConfig(rule.ChildElements["action"]);

            globalRules.Add(rule);

            _Server.CommitChanges();

            _Log.Information($"Rewrite rule '{settings.Name}' created.");
        }

        private static void FillRule(RewriteRuleSettings settings, ConfigurationElement rule)
        {
            rule["name"] = settings.Name;
            rule["patternSyntax"] = settings.PatternSintax;
            rule["stopProcessing"] = settings.StopProcessing;

            var match = rule.ChildElements["match"];

            match["url"] = settings.Pattern;
            match["negate"] = settings.NegatePattern;
            match["ignoreCase"] = settings.IgnoreCase;
        }

        private static void FillConditions(RewriteRuleSettings settings, ConfigurationElement rule)
        {
            var conditions = rule.ChildElements["conditions"];

            conditions["logicalGrouping"] = settings.ConditionsGrouping;

            var conditionsCollection = conditions.GetCollection();

            foreach (var condition in settings.Conditions)
            {
                var conditionsXml = conditionsCollection.CreateElement("add");

                conditionsXml["input"] = condition.ConditionInput;
                conditionsXml["pattern"] = condition.Pattern;
                conditionsXml["negate"] = condition.NegatePattern;
                conditionsXml["ignoreCase"] = condition.IgnoreCase;

                conditionsCollection.Add(conditionsXml);
            }
        }

        /// <summary>
        /// Delete a rewrite rule
        /// </summary>
        /// <param name="name">The name of the rewrite rule</param>
        /// <returns>If the rewrite rule was deleted.</returns>
        public bool DeleteRule(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var globalRuleCollection = GetGlobalRewriteRules();

            var rule = globalRuleCollection.FirstOrDefault(x => x.GetAttributeValue("name").ToString() == name);

            if (rule == null)
            {
                _Log.Information($"Rewrite rule '{name}' was not found.");
                return false;
            }

            globalRuleCollection.Remove(rule);

            _Server.CommitChanges();

            _Log.Information($"Rewrite rule '{name}' deleted.");

            return true;
        }


        /// <summary>
        /// Checks if a rewrite rule exists
        /// </summary>
        /// <param name="name">The name of the rewrite rule</param>
        /// <returns>If the rewrite rule exists.</returns>
        public bool Exists(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var globalRules = GetGlobalRewriteRules();

            return globalRules.Any(x => x.GetAttributeValue("name").ToString() == name);
        }
        #endregion
    }
}