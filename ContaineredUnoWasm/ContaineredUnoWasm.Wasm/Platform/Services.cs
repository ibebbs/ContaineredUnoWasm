using Microsoft.Extensions.Configuration;
using System;

namespace ContaineredUnoWasm.Platform
{
    public static partial class Services
    {
        static partial void AddConfiguration(IConfigurationBuilder builder)
        {
            //var logger = global::Uno.Extensions.LogExtensionPoint.AmbientLoggerFactory.CreateLogger<Services>();

            var variables = Environment.GetEnvironmentVariable("");

            builder.AddEnvironmentVariables("ContaineredUnoWasm:");
        }
    }
}
