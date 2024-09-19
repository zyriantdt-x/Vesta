using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vesta.Navigator.Storage;
using Vesta.Navigator.Storage.Sets;
using Vesta.Shared.Http.Responses.Navigator;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vesta.Navigator.Controllers;
[Route( "api/navigator" )]
[ApiController]
public class NavigatorController : ControllerBase {
    private readonly NavigatorDbContext storage;

    public NavigatorController( NavigatorDbContext storage ) {
        this.storage = storage;
    }

    [Route("category")]
    [HttpGet]
    public async Task<IActionResult> GetCategories( [FromQuery] int? min_rank = null, [FromQuery] int? parent_id = null ) {
        IQueryable<NavigatorCategory> query = this.storage.NavigatorCategories.AsQueryable();

        if( min_rank != null )
            query = query.Where( category => category.MinAccess <= min_rank );
        if( parent_id != null )
            query = query.Where( category => category.ParentId == parent_id );

        List<NavigatorCategoryHttpResponse> res = await query.Select( category => new NavigatorCategoryHttpResponse() {
            Id = category.Id,
            ParentId = category.ParentId,
            Name = category.Name,
            IsNode = category.IsNode,
            IsPublicSpace = category.IsPublicSpace,
            IsTradingAllowed = category.IsTradingAllowed,
            MinAccess = category.MinAccess,
            MinAssign = category.MinAssign
        } ).ToListAsync();

        return this.Ok( res );
    }

    [Route( "category/{id}" )]
    [HttpGet]
    public async Task<IActionResult> GetCategory( int id ) {
        NavigatorCategoryHttpResponse? res = await this.storage.NavigatorCategories
           .Where( category => category.Id == id )
           .Select( category => new NavigatorCategoryHttpResponse() {
               Id = category.Id,
               ParentId = category.ParentId,
               Name = category.Name,
               IsNode = category.IsNode,
               IsPublicSpace = category.IsPublicSpace,
               IsTradingAllowed = category.IsTradingAllowed,
               MinAccess = category.MinAccess,
               MinAssign = category.MinAssign
           } ).FirstOrDefaultAsync();

        if( res == null )
            return this.NotFound();

        return this.Ok( res );
    }
}
