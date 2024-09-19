using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vesta.Shared.Http.Responses.Navigator;

namespace Vesta.Server.ServiceApis;
internal class NavigatorServiceApi : INavigatorServiceApi {
    private const string API_URL = "https://localhost:44398";

    private readonly HttpClient http_client;

    public NavigatorServiceApi() {
        this.http_client = new();
    }

    public async Task<NavigatorCategoryHttpResponse?> GetNavigatorCategoryById( int id ) {
        HttpResponseMessage http_res = await this.http_client.SendAsync( new() {
            Method = HttpMethod.Get,
            RequestUri = new Uri( $"{API_URL}/api/navigator/category/{id}" )
        } );

        if( !http_res.IsSuccessStatusCode )
            return null;

        NavigatorCategoryHttpResponse? http_res_content = JsonSerializer.Deserialize<NavigatorCategoryHttpResponse>( http_res.Content.ReadAsStream() );
        if( http_res_content == null )
            return null;

        return http_res_content;
    }

    public async Task<ICollection<NavigatorCategoryHttpResponse>?> GetNavigatorCategoriesByParentId( int parent_id ) {
        HttpResponseMessage http_res = await this.http_client.SendAsync( new() {
            Method = HttpMethod.Get,
            RequestUri = new Uri( $"{API_URL}/api/navigator/category?parent_id={parent_id}" )
        } );

        if( !http_res.IsSuccessStatusCode )
            return null;

        ICollection<NavigatorCategoryHttpResponse>? http_res_content = await JsonSerializer.DeserializeAsync<List<NavigatorCategoryHttpResponse>>( http_res.Content.ReadAsStream() );
        if( http_res_content == null )
            return null;

        return http_res_content;
    }
}
