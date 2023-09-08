using ConfigServer.API.Configurations;

namespace ConfigServer.API;

public class Program : ApiStartup<ConfigServerStartup>
{
    static async Task Main(string[] args) => await RunAsync();
}

public class ConfigServerStartup : ApiApplicationBootstrapper { }
