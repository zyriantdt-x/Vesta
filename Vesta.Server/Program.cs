using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vesta.Server;
using Vesta.Server.Core;

IApplication app = Host.CreateDefaultBuilder()
                    .ConfigureServices( services => services.AddApplicationServices() )
                    .Build()
                    .Services
                    .GetRequiredService<IApplication>();
await app.Run();

while( true ) { }