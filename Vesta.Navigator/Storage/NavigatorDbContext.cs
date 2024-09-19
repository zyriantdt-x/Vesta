using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Vesta.Navigator.Storage.Sets;

namespace Vesta.Navigator.Storage;

public class NavigatorDbContext : DbContext {
    public DbSet<NavigatorCategory> NavigatorCategories { get; set; }

    public NavigatorDbContext( DbContextOptions<NavigatorDbContext> options ) : base( options ) { }
}
