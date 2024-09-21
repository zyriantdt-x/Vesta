using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vesta.Rooms.Storage;
using Vesta.Rooms.Storage.Sets;
using Vesta.Shared.Http.Requests;
using Vesta.Shared.Http.Responses.Rooms;

namespace Vesta.Rooms.Controllers;
[Route( "api/room_session" )]
[ApiController]
public class RoomSessionController : ControllerBase {
    private readonly RoomsDbContext storage;

    public RoomSessionController( RoomsDbContext storage ) {
        this.storage = storage;
    }

    [Route("create")]
    [HttpPost]
    public async Task<IActionResult> CreateRoomSession( [FromForm] CreateRoomSessionHttpRequest req ) {
        RoomData? room = this.storage.RoomData.Where( room_entity => room_entity.Id == req.RoomId ).FirstOrDefault();
        if( room == null )
            return this.BadRequest();

        CreateRoomSessionHttpResponse res = new() { RoomId = room.Id, Model = room.Model, Floor = room.Floor, Wallpaper = room.Wallpaper };

        return this.Ok( res );
    }
}
