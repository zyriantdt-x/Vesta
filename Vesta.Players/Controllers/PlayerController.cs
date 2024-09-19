using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vesta.Players.Storage;
using Vesta.Players.Storage.Sets;
using Vesta.Shared.Http.Requests;
using Vesta.Shared.Http.Responses;
using Vesta.Shared.Http.Responses.Player;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vesta.Players.Controllers;
[Route( "api/player" )]
[ApiController]
public class PlayerController : ControllerBase {
    private readonly PlayersDbContext storage;

    public PlayerController( PlayersDbContext storage ) {
        this.storage = storage;
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login( [FromForm] LoginHttpRequest body ) {
        PlayerData? user = await this.storage.PlayerData
                                        .Where( player => player.Username == body.Username )
                                        .Where( player => player.Password == body.Password )
                                        .FirstOrDefaultAsync();

        if( user == null )
            return this.Unauthorized();

        return this.Ok( new LoginHttpResponse() {
            PlayerId = user.Id
        } );
    }

    [Route("user_object/{id}")]
    [HttpGet]
    public async Task<IActionResult> UserObject( int id ) {
        PlayerData? user = await this.storage.PlayerData
                                        .Where( player => player.Id == id )
                                        .FirstOrDefaultAsync();

        if( user == null )
            return this.NotFound();

        return this.Ok( new UserObjectHttpResponse() {
            Id = user.Id,
            Username = user.Username,
            Figure = user.Figure,
            Sex = user.Sex ? 'M' : 'F',
            Mission = user.Mission,
            PoolFigure = user.PoolFigure,
            Tickets = user.Tickets,
            Film = user.Film,
            ReceiveNews = user.ReceiveNews,
            Credits = user.Credits
        } );
    }
}
