using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataBaseAndStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            // Creacion de un procedimiento almacenado para insertar un producto
            migrationBuilder.Sql(@"CREATE PROCEDURE CreateProduct    
            @Name NVARCHAR(100), @Description NVARCHAR(255),    
            @Price DECIMAL(18, 2), @Stock INT
            AS BEGIN
            INSERT INTO Products (Name, Description, Price, Stock)
            VALUES (@Name, @Description, @Price, @Stock); END");

            // Creacion de un procedimiento almacenado para obtener todos los productos
            migrationBuilder.Sql(@"CREATE PROCEDURE GetProducts AS BEGIN SELECT * FROM Products; END");

            // Creacion de un procedimiento almacenado para obtener un producto por su Id
            migrationBuilder.Sql(@"CREATE PROCEDURE GetProductById @Id INT AS BEGIN 
            SELECT * FROM Products WHERE Id = @Id; END");

            // Creacion de un procedimiento almacenado para actualizar un producto
            migrationBuilder.Sql(@"CREATE PROCEDURE UpdateProduct
            @Id INT, @Name NVARCHAR(100), @Description NVARCHAR(255),
            @Price DECIMAL(18, 2), @Stock INT
            AS BEGIN
            UPDATE Products SET 
            Name = @Name, Description = @Description, 
            Price = @Price, Stock = @Stock
            WHERE Id = @Id; END");

            // Creacion de un procedimiento almacenado para eliminar un producto
            migrationBuilder.Sql(@"CREATE PROCEDURE DeleteProduct @Id INT AS BEGIN
            DELETE FROM Products WHERE Id = @Id; END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Products");
            migrationBuilder.Sql("DROP PROCEDURE CreateProduct");
            migrationBuilder.Sql("DROP PROCEDURE GetProducts");
            migrationBuilder.Sql("DROP PROCEDURE GetProductById");
            migrationBuilder.Sql("DROP PROCEDURE UpdateProduct");
            migrationBuilder.Sql("DROP PROCEDURE DeleteProduct");
        }
    }
}
