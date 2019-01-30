using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Test.Configuration
{
    public abstract class BaseConfigurationManager
    {
        public IConfiguration Configuration { get; internal set; }
    }

    public class ConfigurationManager : BaseConfigurationManager
    {
        public ConfigurationManager(IEnumerable<string> settings, IHostingEnvironment env = null)
        {
            string basePath = env == null ? Directory.GetCurrentDirectory() : env.ContentRootPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath);

            foreach (var setting in settings)
            {
                if (setting.Length > 5 && setting.Substring(setting.Length - 5, 5) == ".json")
                {
                    builder.AddJsonFile(setting, optional: false, reloadOnChange: true);
                    if (env != null)
                    {
                        builder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                        //if (env.IsDevelopment())
                        //{
                        //    // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                        //    builder.AddUserSecrets<Startup>();
                        //}
                    }
                }
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        //public string GetConfigurationValue(string key)
        //{
        //    return Configuration.GetConnectionString()
        //}
    }
}
