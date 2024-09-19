using Microsoft.EntityFrameworkCore;
using Vesta.Players.Storage;

WebApplicationBuilder builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddDbContext<PlayersDbContext>( options => {
    string connection_string = "server=localhost;database=vesta_players;user=root;password=;";
    options.UseMySql( connection_string, ServerVersion.AutoDetect( connection_string ) );
} );

builder.Services.AddControllers();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
