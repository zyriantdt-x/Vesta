using Microsoft.EntityFrameworkCore;
using Vesta.Rooms.Storage.Sets;

namespace Vesta.Rooms.Storage;

public class RoomsDbContext : DbContext {
    public DbSet<RoomData> RoomData { get; set; }
    public DbSet<RoomModel> RoomModels { get; set; }

    public RoomsDbContext(DbContextOptions<RoomsDbContext> options) : base(options) { }
}
