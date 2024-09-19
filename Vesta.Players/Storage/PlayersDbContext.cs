using Microsoft.EntityFrameworkCore;
using Vesta.Players.Storage.Sets;

namespace Vesta.Players.Storage;

public class PlayersDbContext : DbContext {
    public DbSet<PlayerData> PlayerData { get; set; }

    public PlayersDbContext(DbContextOptions<PlayersDbContext> options) : base(options) { }
}
