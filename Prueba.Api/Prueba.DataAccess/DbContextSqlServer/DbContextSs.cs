using Microsoft.EntityFrameworkCore;
using Prueba.Models.Models;

namespace Prueba.DataAccess.DbContextSqlServer;

public class DbContextSs(DbContextOptions options) : DbContext(options)
{
    #region 
        
    public DbSet<ProductsModel> Products { get; set; }

    #endregion DbSet

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductsModel>().HasIndex(product => product.Name).IsUnique();

        base.OnModelCreating(modelBuilder);
    }

}