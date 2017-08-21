#region Using Statements
using System;
using System.Linq;
using System.IO;
using System.Threading;

using Cake.Core;

using Microsoft.Web.Administration;
using NSubstitute;
#endregion



namespace Cake.IIS.Tests
{
    internal static class CakeHelper
    {
        #region Functions (4)
        //Cake
        public static ICakeEnvironment CreateEnvironment()
        {
            var environment = Substitute.For<ICakeEnvironment>();
            environment.WorkingDirectory = Directory.GetCurrentDirectory();

            return environment;
        }



        //Managers
        public static ApplicationPoolManager CreateApplicationPoolManager()
        {
            ApplicationPoolManager manager = new ApplicationPoolManager(CakeHelper.CreateEnvironment(), new DebugLog());

            manager.SetServer();

            return manager;
        }

        public static FtpsiteManager CreateFtpsiteManager()
        {
            FtpsiteManager manager = new FtpsiteManager(CakeHelper.CreateEnvironment(), new DebugLog());

            manager.SetServer();

            return manager;
        }

        public static WebsiteManager CreateWebsiteManager()
        {
            WebsiteManager manager = new WebsiteManager(CakeHelper.CreateEnvironment(), new DebugLog());

            manager.SetServer();

            return manager;
        }
        
        public static WebFarmManager CreateWebFarmManager()
        {
            WebFarmManager manager = new WebFarmManager(CakeHelper.CreateEnvironment(), new DebugLog());

            manager.SetServer();

            return manager;
        }



        //Settings
        public static ApplicationPoolSettings GetAppPoolSettings(string name = "DC")
        {
            return new ApplicationPoolSettings
            {
                Name = name,
                IdentityType = IdentityType.NetworkService,
                Autostart = true,
                MaxProcesses = 1,
                Enable32BitAppOnWin64 = false,

                IdleTimeout = TimeSpan.FromMinutes(20),
                ShutdownTimeLimit = TimeSpan.FromSeconds(90),
                StartupTimeLimit = TimeSpan.FromSeconds(90),

                PingingEnabled = true,
                PingInterval = TimeSpan.FromSeconds(30),
                PingResponseTime = TimeSpan.FromSeconds(90),
                Overwrite = false
            };
        }

        public static WebsiteSettings GetWebsiteSettings(string name = "Superman")
        {
            WebsiteSettings settings = new WebsiteSettings
            {
                Name = name,
                PhysicalDirectory = "./Test/",
                ApplicationPool = CakeHelper.GetAppPoolSettings(),
                ServerAutoStart = true,
                Overwrite = false
            };

            settings.Binding = IISBindings.Http
                .SetHostName(name + ".web")
                .SetIpAddress("*")
                .SetPort(80);

            return settings;
        }

        public static ApplicationSettings GetApplicationSettings(string siteName)
        {
            return new ApplicationSettings
            {
                ApplicationPath = "/Test",
                ApplicationPool = CakeHelper.GetAppPoolSettings().Name,
                VirtualDirectory = "/",
                PhysicalDirectory = "./Test/App/",
                SiteName = siteName,
            };
        }

        public static WebFarmSettings GetWebFarmSettings()
        {
            return new WebFarmSettings
            {
                Name = "Batman",
                Servers = new string[] { "Gotham", "Metroplis" }
            };
        }

        public static AuthenticationSettings GetAuthenticationSettings(bool anonymous, bool basic, bool windows)
        {
            return new AuthenticationSettings()
            {
                EnableAnonymousAuthentication = anonymous,
                EnableBasicAuthentication = basic,
                EnableWindowsAuthentication = windows
            };
        }

     



        //Website
        public static void CreateWebsite(WebsiteSettings settings)
        {
            WebsiteManager manager = CakeHelper.CreateWebsiteManager();

            manager.Create(settings);
        }

        public static void DeleteWebsite(string name)
        {
            using (var server = new ServerManager())
            {
                var site = server.Sites.FirstOrDefault(x => x.Name == name);

                if (site != null)
                {
                    server.Sites.Remove(site);
                    server.CommitChanges();
                }
            }
        }

        public static Site GetWebsite(string name)
        {
            using (var serverManager = new ServerManager())
            {
                var site = serverManager.Sites.FirstOrDefault(x => x.Name == name);
                // Below is required to fetch ApplicationDefaults before disposing ServerManager.
                if (site != null && site.ApplicationDefaults != null)
                {
                    return site;
                }
                return site;
            }
        }

        public static Application GetApplication(string siteName, string appPath)
        {
            using (var serverManager = new ServerManager())
            {
                var site = serverManager.Sites.FirstOrDefault(x => x.Name == siteName) ;
                return site != null ? site.Applications.FirstOrDefault(a => a.Path == appPath) : null;
            }
        }

        public static void StartWebsite(string name)
        {
            using (var server = new ServerManager())
            {
                Site site = server.Sites.FirstOrDefault(x => x.Name == name);

                if (site != null)
                {
                    try
                    {
                        site.Start();
                    }
                    catch (System.Runtime.InteropServices.COMException)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        public static void StopWebsite(string name)
        {
            using (var server = new ServerManager())
            {
                Site site = server.Sites.FirstOrDefault(x => x.Name == name);

                if (site != null)
                {
                    try
                    {
                        site.Stop();
                    }
                    catch (System.Runtime.InteropServices.COMException)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
        }



        //Pool
        public static void CreatePool(ApplicationPoolSettings settings)
        {
            ApplicationPoolManager manager = CakeHelper.CreateApplicationPoolManager();

            manager.Create(settings);
        }

        public static void DeletePool(string name)
        {
            using (var server = new ServerManager())
            {
                ApplicationPool pool = server.ApplicationPools.FirstOrDefault(x => x.Name == name);

                if (pool != null)
                {
                    server.ApplicationPools.Remove(pool);
                    server.CommitChanges();
                }
            }
        }

        public static ApplicationPool GetPool(string name)
        {
            using (var server = new ServerManager())
            {
                return server.ApplicationPools.FirstOrDefault(x => x.Name == name);
            }
        }

        public static void StartPool(string name)
        {
            using (var server = new ServerManager())
            {
                ApplicationPool pool = server.ApplicationPools.FirstOrDefault(x => x.Name == name);

                if (pool != null)
                {
                    try
                    {
                        pool.Start();
                    }
                    catch (System.Runtime.InteropServices.COMException)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        public static void StopPool(string name)
        {
            using (var server = new ServerManager())
            {
                ApplicationPool pool = server.ApplicationPools.FirstOrDefault(x => x.Name == name);

                if (pool != null)
                {
                    try
                    {
                        pool.Stop();
                    }
                    catch (System.Runtime.InteropServices.COMException)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
        }

            //Authentication
            public static AuthenticationSettings ReadAuthenticationSettings(string websiteName)
            {
                var element = "system.webServer/security/authentication/{0}";
                var anon = GetSectionElementValue<bool>(string.Format(element, "anonymousAuthentication"), "enabled", websiteName);
                var basic = GetSectionElementValue<bool>(string.Format(element, "basicAuthentication"), "enabled", websiteName);
                var windows = GetSectionElementValue<bool>(string.Format(element, "windowsAuthentication"), "enabled", websiteName);

                return  new AuthenticationSettings()
                {
                    EnableWindowsAuthentication = windows,
                    EnableBasicAuthentication = basic,
                    EnableAnonymousAuthentication = anon
                };

            }

            //General
            public static T GetSectionElementValue<T>(string elementPath, string attributeName, string location)
            {
                using (var serverManager = new ServerManager())
                {
                    var config = serverManager.GetApplicationHostConfiguration();
                    var element =config.GetSection(elementPath, location);
                    var t = typeof(T);
                    return (T)Convert.ChangeType( element[attributeName], t);
                }
            }

        //WebFarm
        public static void CreateWebFarm(WebFarmSettings settings)
        {
            WebFarmManager manager = CakeHelper.CreateWebFarmManager();

            manager.Create(settings);
        }

        public static void DeleteWebFarm(string name)
        {
            using (var serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetApplicationHostConfiguration();

                ConfigurationSection section = config.GetSection("webFarms");
                ConfigurationElementCollection farms = section.GetCollection();

                ConfigurationElement farm = farms.FirstOrDefault(f => f.GetAttributeValue("name").ToString() == name);

                if (farm != null)
                {
                    farms.Remove(farm);
                    serverManager.CommitChanges();
                }
            }
        }

        public static ConfigurationElement GetWebFarm(string name)
        {
            using (var serverManager = new ServerManager())
            {
                Configuration config = serverManager.GetApplicationHostConfiguration();

                ConfigurationSection section = config.GetSection("webFarms");
                ConfigurationElementCollection farms = section.GetCollection();

                return farms.FirstOrDefault(f => f.GetAttributeValue("name").ToString() == name);
            }
        }
        #endregion
    }
}