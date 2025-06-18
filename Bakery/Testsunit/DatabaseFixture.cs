
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities;

public class DatabaseFixture : IDisposable
{
    public BakeryDBContext Context { get; private set; }

    public DatabaseFixture()
    {
        var options = new DbContextOptionsBuilder<BakeryDBContext>()
            .UseSqlServer("Server=localhost;Database=Bakery_Test;Trusted_Connection=True;")
            .Options;

        Context = new BakeryDBContext(options);

        // מומלץ למחוק וליצור מחדש כדי לוודא סביבה נקייה
        Context.Database.EnsureDeleted();
        Context.Database.Migrate(); // או EnsureCreated אם אין לך מיגרציות
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}