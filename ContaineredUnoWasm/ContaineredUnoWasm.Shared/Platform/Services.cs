using ContaineredUnoWasm.Shared;
using Microsoft.Extensions.Configuration;

namespace ContaineredUnoWasm.Platform
{
    public static partial class Services
    {
        static partial void AddConfiguration(IConfigurationBuilder builder);

        public static Configuration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder();

            AddConfiguration(builder);

            var config = builder.Build();

            var result = new Configuration();

            ConfigurationBinder.Bind(config.GetSection("Hello"), result);

            return result;
        }
    }
}
