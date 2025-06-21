using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities;
using Bakery;

public class UsersDataIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly BakeryDBContext _context;
    private readonly UsersData _usersData;
    public UsersDataIntegrationTests(DatabaseFixture fixture)
    {
        _context = fixture.Context;
        _usersData = new UsersData(_context);
    }


    [Fact]
    public async Task Register_And_Login_User_Success()
    {
        // Arrange
        var usersData = new UsersData(_context);

        var user = new User
        {
            Username = "testuser",
            Password = "password123",
            Firstname = "Test",
            Lastname = "test family"
        };

        // Act
        await usersData.Register(user);
        var result = await usersData.Login(new User { Username = "testuser", Password = "password123" });

        // Assert
        Assert.NotNull(result);
        Assert.Equal("testuser", result.Username);
    }

    [Fact]
    public async Task Register_DuplicateUsername_ThrowsException()
    {
        // Arrange
        var usersData = new UsersData(_context);

        var user1 = new User { Username = "duplicate", Password = "123" };
        var user2 = new User { Username = "duplicate", Password = "456" };

        await usersData.Register(user1);

        // Act + Assert
        var ex = await Assert.ThrowsAsync<HttpStatusException>(() => usersData.Register(user2));
        Assert.Equal(409, ex.StatusCode);
    }
}