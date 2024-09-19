using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vesta.Server.Sessions;
using Vesta.Shared.Http.Requests;
using Vesta.Shared.Http.Responses.Player;

namespace Vesta.Server.ServiceApis;
internal class PlayerServiceApi : IPlayerServiceApi {
    private const string API_URL = "https://localhost:44350";

    private readonly HttpClient http_client;

    public PlayerServiceApi() {
        this.http_client = new HttpClient();
    }

    public async Task<LoginHttpResponse?> Login( LoginHttpRequest req ) {
        HttpResponseMessage http_res = await this.http_client.SendAsync( new() {
            Method = HttpMethod.Post,
            RequestUri = new Uri( $"{API_URL}/api/player/login" ),
            Content = new FormUrlEncodedContent( req.Compose() )
        } );

        if( !http_res.IsSuccessStatusCode )
            return null;

        LoginHttpResponse? http_res_content = await JsonSerializer.DeserializeAsync<LoginHttpResponse>( http_res.Content.ReadAsStream() );
        if( http_res_content == null )
            return null;

        return http_res_content;
    }

    public async Task<UserObjectHttpResponse?> GetUserObject( int id ) {
        HttpResponseMessage http_res = await this.http_client.SendAsync( new() {
            Method = HttpMethod.Get,
            RequestUri = new Uri( $"{API_URL}/api/player/user_object/{id}" ),
        } );

        if( !http_res.IsSuccessStatusCode )
            return null;

        UserObjectHttpResponse? http_res_content = await JsonSerializer.DeserializeAsync<UserObjectHttpResponse>( http_res.Content.ReadAsStream() );
        if( http_res_content == null )
            return null;

        return http_res_content;
    }
}
