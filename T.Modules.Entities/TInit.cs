using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Test.Modules.Entities
{

    public static class ServiceCollectionExtension
    {
        private static IConfiguration _configuration;
        public static void TestInit(this IServiceCollection services, IConfiguration configuration)
        {
            _configuration = configuration;
            // uncomment to test config
            // File.AppendAllText("_dataConnectionString.txt", GetConfigurationValue("dataConnection"));
        }
        private static string GetConfigurationValue(string key)
        {
            return _configuration.GetConnectionString(key);
        }
    }
}
