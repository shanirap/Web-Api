using Xunit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Repositories;
using Entities;
using Bakery;
using System.Collections.Generic;
using System.Linq;

public class ProductsDataIntegrationTests :IClassFixture<DatabaseFixture>
{
    private readonly BakeryDBContext _context;
    private readonly ProductsData _productsData;
    public ProductsDataIntegrationTests(DatabaseFixture fixture)
    {
        _context = fixture.Context;
        _productsData = new ProductsData(_context);
    }


    [Fact]
    public async Task GetProducts_ReturnsProductsWithCategories()
    {
      

        using (_context)
        {
            var category = new Catgory { Id = 1, CatgoryName = "Cakes" };
            var product = new Product
            {
                Id = 1,
                ProductName = "Chocolate Cake",
                Price = 25,
                CategoryId = 1,
                Category = category
            };

            _context.Catgories.Add(category);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        using (_context)
        {
            var productsData = new ProductsData(_context);

            // Act
            var result = await productsData.getProducts();

            // Assert
            Assert.Single(result);
            Assert.Equal("Chocolate Cake", result.First().ProductName);
            Assert.NotNull(result.First().Category);
            Assert.Equal("Cakes", result.First().Category.CatgoryName);
        }
    }
}