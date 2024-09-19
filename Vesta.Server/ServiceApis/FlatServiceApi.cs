using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vesta.Shared.Http.Responses.Rooms;

namespace Vesta.Server.ServiceApis;
internal class FlatServiceApi : IFlatServiceApi {
    private const string API_URL = "https://localhost:44375";

    private readonly HttpClient http_client;

    public FlatServiceApi() {
        this.http_client = new();
    }

    public async Task<GetFlatHttpResponse?> GetFlatById( int id ) {
        HttpResponseMessage http_res = await this.http_client.SendAsync( new() {
            Method = HttpMethod.Get,
            RequestUri = new Uri( $"{API_URL}/api/room_data/flat/{id}" )
        } );

        if( !http_res.IsSuccessStatusCode )
            return null;

        GetFlatHttpResponse? http_res_content = await JsonSerializer.DeserializeAsync<GetFlatHttpResponse>( http_res.Content.ReadAsStream() );
        if( http_res_content == null )
            return null;

        return http_res_content;
    }

    public async Task<ICollection<GetFlatHttpResponse>?> GetFlatsByCategoryId( int category_id ) {
        HttpResponseMessage http_res = await this.http_client.SendAsync( new() {
            Method = HttpMethod.Get,
            RequestUri = new Uri( $"{API_URL}/api/room_data/flat?category_id={category_id}" )
        } );

        if( !http_res.IsSuccessStatusCode )
            return null;

        ICollection<GetFlatHttpResponse>? http_res_content = await JsonSerializer.DeserializeAsync<List<GetFlatHttpResponse>>( http_res.Content.ReadAsStream() );
        if( http_res_content == null )
            return null;

        return http_res_content;
    }

    public async Task<RoomModelHttpResponse?> GetRoomModelByName( string name ) {
        HttpResponseMessage http_res = await this.http_client.SendAsync( new() {
            Method = HttpMethod.Get,
            RequestUri = new Uri( $"{API_URL}/api/room_data/model/{name}" )
        } );

        if( !http_res.IsSuccessStatusCode )
            return null;

        RoomModelHttpResponse? http_res_content = await JsonSerializer.DeserializeAsync<RoomModelHttpResponse>( http_res.Content.ReadAsStream() );
        if( http_res_content == null )
            return null;

        return http_res_content;
    }
}
