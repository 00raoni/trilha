using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using trilha_net.Tests.Fixtures;

namespace trilha_net.Tests.Factories
{
    [Collection("Database")]
    public class TrilhaFactory:WebApplicationFactory<Program>
    {
        private readonly DbFixture _dbFixture;
        public TrilhaFactory(DbFixture dbFixture)
        {
            _dbFixture = dbFixture;
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            builder.ConfigureServices(services =>
            {

            });
            builder.ConfigureAppConfiguration((context, configuration) =>
            {
                configuration.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>("Connections:ConnectionString",_dbFixture.ConnectionString),
                });
            });            
        }
    }
}
