using Microsoft.EntityFrameworkCore;
using Vesta.Rooms.Storage;

var builder = WebApplication.CreateBuilder( args );

builder.Services.AddDbContext<RoomsDbContext>( options => {
    string connection_string = "server=localhost;database=vesta_rooms;user=root;password=;";
    options.UseMySql( connection_string, ServerVersion.AutoDetect( connection_string ) );
} );

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
