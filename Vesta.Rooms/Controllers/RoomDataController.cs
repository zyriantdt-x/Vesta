using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vesta.Rooms.Storage;
using Vesta.Rooms.Storage.Sets;
using Vesta.Shared.Http.Responses.Rooms;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vesta.Rooms.Controllers;
[Route( "api/room_data" )]
[ApiController]
public class RoomDataController : ControllerBase {
    private readonly RoomsDbContext storage;

    public RoomDataController( RoomsDbContext storage ) {
        this.storage = storage;
    }

    [Route( "flat/{id}" )]
    [HttpGet]
    public async Task<IActionResult> GetFlat( int id ) {
        GetFlatHttpResponse? res = await this.storage.RoomData
            .Where( flat => flat.Id == id )
            .Select( flat => new GetFlatHttpResponse() {
                Id = flat.Id,
                OwnerId = Convert.ToInt32( flat.OwnerId ),
                Category = flat.Category,
                Name = flat.Name,
                Description = flat.Description,
                Model = flat.Model,
                Ccts = flat.Ccts,
                Wallpaper = flat.Wallpaper,
                Floor = flat.Floor,
                ShowName = flat.ShowName,
                SuperUsers = flat.SuperUsers,
                AccessType = flat.AccessType,
                Password = flat.Password,
                VisitorsNow = flat.VisitorsNow,
                VisitorsMax = flat.VisitorsMax,
                Rating = flat.Rating,
                IsHidden = flat.IsHidden,
                CreatedAt = flat.CreatedAt,
                UpdatedAt = flat.UpdatedAt
            } )
            .FirstOrDefaultAsync();

        if( res == null )
            return this.NotFound();

        return this.Ok( res );
    }

    [Route( "flat" )]
    [HttpGet]
    public async Task<IActionResult> GetFlats( [FromQuery] int? category_id ) {
        List<GetFlatHttpResponse> flats = await this.storage.RoomData
            .Where( flat => flat.Category == category_id )
            .Select( flat => new GetFlatHttpResponse() {
                Id = flat.Id,
                OwnerId = Convert.ToInt32(flat.OwnerId),
                Category = flat.Category,
                Name = flat.Name,
                Description = flat.Description,
                Model = flat.Model,
                Ccts = flat.Ccts,
                Wallpaper = flat.Wallpaper,
                Floor = flat.Floor,
                ShowName = flat.ShowName,
                SuperUsers = flat.SuperUsers,
                AccessType = flat.AccessType,
                Password = flat.Password,
                VisitorsNow = flat.VisitorsNow,
                VisitorsMax = flat.VisitorsMax,
                Rating = flat.Rating,
                IsHidden = flat.IsHidden,
                CreatedAt = flat.CreatedAt,
                UpdatedAt = flat.UpdatedAt
            } )
            .ToListAsync();

        return this.Ok( flats );
    }

    [Route( "model/{name}" )]
    [HttpGet]
    public async Task<IActionResult> GetRoomModel( string name ) {
        RoomModelHttpResponse? res = await this.storage.RoomModels
            .Where( model => model.Name == name )
            .Select( model => new RoomModelHttpResponse() {
                Id = model.Id,
                Name = model.Name,
                DoorX = model.DoorX,
                DoorY = model.DoorY,
                DoorZ = model.DoorZ,
                DoorDir = model.DoorDir,
                Heightmap = model.Heightmap,
                TriggerClass = model.TriggerClass
            } )
            .FirstOrDefaultAsync();

        if( res == null )
            return this.NotFound();

        return this.Ok( res );
    }
}
