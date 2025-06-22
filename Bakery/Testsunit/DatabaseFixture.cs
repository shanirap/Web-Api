using Microsoft.EntityFrameworkCore;
using Repositories;

public class DatabaseFixture : IDisposable
{
    public BakeryDBContext Context { get; private set; }

    public DatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<BakeryDBContext>()
            .UseSqlServer("Server=DESKTOP-BPOB0SQ;Database=Bakery_Test;Trusted_Connection=True;TrustServerCertificate=True;")
            .Options;

        Context = new BakeryDBContext(options);

        //Context.Database.EnsureDeleted();
        Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}
