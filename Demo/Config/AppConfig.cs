namespace Demo.Config
{
    using Microsoft.Extensions.Configuration;
    class AppConfig
    {
        /// <summary>
        /// Get the value corresponding to the key from App.config settings
        /// </summary>
        /// <param name="key">The key name</param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return AppConfig.GetConfig()[key];
        }
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);
            return builder.Build();
        }
    }
}
