using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Prueba.DataAccess.DbContextSqlServer;
using Prueba.Domains.Interfaces;
using Prueba.Models.DTOs.Universals;
using Prueba.Models.Models;
using System.Data;

namespace Prueba.Domains.Domains
{
    public class ProductDomain(DbContextSs dbContext) : IProductDomain
    {
        /// <summary>
        /// Metodo para crear un producto
        /// </summary>
        /// <param name="product">Se requiere el modelo con la informacion cargada para la craeacion del producto</param>
        /// <returns></returns>
        public async Task<UniversalResponseDto<bool>> CreateProduct(ProductsModel product)
        {
            var response = new UniversalResponseDto<bool>();
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@Name", SqlDbType.NVarChar) { Value = product.Name },
                    new SqlParameter("@Description", SqlDbType.NVarChar) { Value = product.Description },
                    new SqlParameter("@Price", SqlDbType.Decimal) { Value = product.Price },
                    new SqlParameter("@Stock", SqlDbType.Int) { Value = product.Stock }
                };


                var value = await dbContext.Database.ExecuteSqlRawAsync("EXEC CreateProduct @Name, @Description, @Price, @Stock", parameters);
                if (value != 0)
                {
                    response.Response = true;
                    response.Code = System.Net.HttpStatusCode.Created;
                }
                else
                {
                    response.Response = false;
                    response.Code = System.Net.HttpStatusCode.BadRequest;
                }
                return response;
            }
            catch (Exception e)
            {
                var sqlCode = e.Message.Contains("unique");
                if (sqlCode)
                {
                    response.Response = false;
                    response.Code = System.Net.HttpStatusCode.BadRequest;
                }
                else
                {
                    response.Code = System.Net.HttpStatusCode.InternalServerError;
                }

                return response;
            }
        }

        /// <summary>
        /// Metodo para eliminar un producto
        /// </summary>
        /// <param name="id">Requier el id del producto a eliminar</param>
        /// <returns></returns>
        public async Task<UniversalResponseDto<bool>> DeleteProduct(int id)
        {
            var response = new UniversalResponseDto<bool>();
            try
            {
                var parameter = new SqlParameter("@Id", SqlDbType.Int) { Value = id };

                var value = await dbContext.Database.ExecuteSqlRawAsync("EXEC DeleteProduct @Id", parameter);
                if (value != 0)
                {
                    response.Response = true;
                    response.Code = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Response = false;
                    response.Code = System.Net.HttpStatusCode.BadRequest;
                }
                return response;
            }
            catch (Exception)
            {
                response.Code = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }

        /// <summary>
        /// Metodo para obtener un producto por id
        /// </summary>
        /// <param name="id">Id del producto</param>
        /// <returns></returns>
        public async Task<UniversalResponseDto<ProductsModel>> GetProductById(int id)
        {
            var response = new UniversalResponseDto<ProductsModel>();
            try
            {

                var parameter = new SqlParameter("@Id", SqlDbType.Int) { Value = id };

                var product = dbContext.Products.FromSqlRaw("EXEC GetProductById @Id", parameter).AsEnumerable().FirstOrDefault();
                if (product != null)
                {
                    response.Response = product;
                    response.Code = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Code = System.Net.HttpStatusCode.NotFound;
                }
                return response;
            }
            catch (Exception)
            {
                response.Code = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }

        /// <summary>
        /// Metodo para obtener los productos de la base de datos
        /// </summary>
        /// <returns></returns>
        public async Task<UniversalResponseDto<List<ProductsModel>>> GetProducts()
        {
            var response = new UniversalResponseDto<List<ProductsModel>>();

            try
            {
                var productList = await dbContext.Products.FromSqlRaw("EXEC GetProducts").ToListAsync();

                if (productList != null)
                {
                    response.Response = productList;
                    response.Code = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Code = System.Net.HttpStatusCode.NotFound;
                }

                return response;
            }
            catch (Exception)
            {
                response.Code = System.Net.HttpStatusCode.InternalServerError;
                return response;
            }
        }


        /// <summary>
        /// Metodo para actualizar un producto
        /// </summary>
        /// <param name="product">Requiere el modelo con la informacion cargada</param>
        /// <returns></returns>
        public async Task<UniversalResponseDto<bool>> UpdateProduct(ProductsModel product)
        {
            var response = new UniversalResponseDto<bool>();
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@Id", SqlDbType.Int) { Value = product.Id },
                    new SqlParameter("@Name", SqlDbType.NVarChar) { Value = product.Name },
                    new SqlParameter("@Description", SqlDbType.NVarChar) { Value = product.Description },
                    new SqlParameter("@Price", SqlDbType.Decimal) { Value = product.Price },
                    new SqlParameter("@Stock", SqlDbType.Int) { Value = product.Stock }
                };

                var value = await dbContext.Database.ExecuteSqlRawAsync("EXEC UpdateProduct @Id, @Name, @Description, @Price, @Stock", parameters);
                if (value != 0)
                {
                    response.Response = true;
                    response.Code = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Response = false;
                    response.Code = System.Net.HttpStatusCode.BadRequest;
                }
                return response;
            }
            catch (Exception e)
            {
                var sqlCode = e.Message.Contains("unique");
                if (sqlCode)
                {
                    response.Response = false;
                    response.Code = System.Net.HttpStatusCode.BadRequest;
                }
                else
                {
                    response.Code = System.Net.HttpStatusCode.InternalServerError;
                }
                return response;
            }
        }
    }
}
