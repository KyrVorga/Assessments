using AdminClient;
using Microsoft.Extensions.Configuration;
using RestAPIClient;

namespace WinFormsApp
{
    internal static class Program
    {
        public static IAPIConfiguration Configuration;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            Configuration = configuration.GetSection("APIConfiguration").Get<APIConfiguration>();


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}