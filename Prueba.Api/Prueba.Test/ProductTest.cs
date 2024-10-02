using Microsoft.EntityFrameworkCore;
using Prueba.DataAccess.DbContextSqlServer;
using Prueba.Domains.Domains;
using Prueba.Models.Models;

namespace Prueba.Test
{
    public class ProductTest
    {
        private ProductDomain _productDomain;

        public ProductTest()
        {
            _productDomain = new ProductDomain(GetDatabaseContext());
        }
        public DbContextSs GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DbContextSs>().UseSqlServer("Server=localhost; Database=prueba_db; User Id=ivantorres; Password=ivantorres; Trusted_Connection=True; TrustServerCertificate=True;").Options;
            return new DbContextSs(options);
        }

        // Validar que el producto exista
        [Fact]
        public async Task CreateProduct_ShouldReturnCreatedResult_WhenProductIsValid()
        {
            // Arrange
            await using var context = GetDatabaseContext();
            var product = new ProductsModel { Name = "Tenis Nike 00", Description = "Description sueabes", Price = 10000.00M, Stock = 50 };

            // Act
            var result = await _productDomain.CreateProduct(product);

            // Assert
            Assert.True(result.Response, "Existe un producto ya creado con esa referencia");
            Assert.Equal(System.Net.HttpStatusCode.Created, result.Code);
        }

        // Validar que el nombre del producto sea unico
        [Fact]
        public async Task CreateProduct_ShouldReturnCreatedResult_WhenProductIsInValid()
        {
            // Arrange
            await using var context = GetDatabaseContext();
            var product = new ProductsModel { Name = "Tenis Nike 00", Description = "Description sueabes", Price = 100.00M, Stock = 100 };

            // Act
            var result = await _productDomain.CreateProduct(product);

            // Assert
            Assert.False(result.Response);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result.Code);
        }

        // Valida que se obtenga los productos
        [Fact]
        public async Task GetProducts_ShouldReturnOkResult_WithListOfProducts()
        {
            // Act
            var result = await _productDomain.GetProducts();

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, result.Code);
        }

        // Valida que se obtena un producto por id
        [Fact]
        public async Task GetProductById_ShouldReturnOkResult_WithProduct()
        {
            // Arrange
            var id = 12;

            // Act
            var result = await _productDomain.GetProductById(id);

            // Assert
            Assert.NotEqual(0, result.Response.Id);
            Assert.NotEmpty(result.Response.Name);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.Code);
        }

        // Valida la actualizacion del producto
        [Fact]
        public async Task UpdateProduct_ShouldReturnOkResult_WhenProductIsUpdated()
        {
            // Arrange
            var product = new ProductsModel { Id = 22, Name = "Tenis Nike 02", Description = "Description sueabes", Price = 10000.00M, Stock = 50 };

            // Act
            var result = await _productDomain.UpdateProduct(product);

            // Assert
            Assert.True(result.Response);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.Code);
        }

        //Valida la eliminacion del producto
        [Fact]
        public async Task DeleteProduct_ShouldReturnOkResult_WhenProductIsDeleted()
        {
            // Arrange
            var id = 39;

            // Act
            var result = await _productDomain.DeleteProduct(id);

            // Assert
            Assert.True(result.Response);
            Assert.Equal(System.Net.HttpStatusCode.OK, result.Code);
        }
    }
}
