using Xunit;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities;
using Bakery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CategoriesDataIntegrationTests :IClassFixture<DatabaseFixture>
{
    private readonly BakeryDBContext _context;
    private readonly CategoriesData _categoriesData;
    public CategoriesDataIntegrationTests(DatabaseFixture fixture)
    {
        _context = fixture.Context;
        _categoriesData = new CategoriesData(_context);
    }


    [Fact]
    public async Task GetCategories_ReturnsAllInsertedCategories()
    {
        // Arrange

        
            _context.Catgories.AddRange(
                new Catgory { CatgoryName = "Cakes" },
                new Catgory {  CatgoryName = "Cookies" }
            );
            await _context.SaveChangesAsync();
        


            var categoriesData = new CategoriesData(_context);

            // Act
            var categories = await categoriesData.getCatgories();

            // Assert
            Assert.Equal(2, categories.Count);
            Assert.Contains(categories, c => c.CatgoryName == "Cakes");
            Assert.Contains(categories, c => c.CatgoryName == "Cookies");
        
    }

    [Fact]
    public async Task GetCategories_WhenNoneExist_ReturnsEmptyList()
    {
        // Arrange


            var categoriesData = new CategoriesData(_context);

            // Act
            var categories = await categoriesData.getCatgories();

            // Assert
            Assert.Empty(categories);
        }
    }
