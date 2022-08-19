using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repositories
{
    public class ProductRepositoryStoredProcedure : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepositoryStoredProcedure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Product entity)
        {
            entity.AddedOn = DateTime.Now;

            var parameters = new DynamicParameters();
            AddPeriodParameters(parameters, entity);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync("sp_AddProduct", parameters, commandType: CommandType.StoredProcedure);
 
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.UInt32);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync("sp_DeleteById", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Product>("sp_GetAllProducts", commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.UInt32);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Product>("sp_GetProductById", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> UpdateAsync(Product entity)
        {
            entity.ModifiedOn = DateTime.Now;

            var parameters = new DynamicParameters();
            AddPeriodParameters(parameters, entity);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync("sp_UpdateProduct", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        private void AddPeriodParameters(DynamicParameters parameters, Product product)
        {
            parameters.Add("@Id", product.Id, DbType.UInt32);
            parameters.Add("@Name", product.Name, DbType.String);
            parameters.Add("@Description", product.Description, DbType.String);
            parameters.Add("@Barcode", product.Barcode, DbType.String);
            parameters.Add("@Rate", product.Rate, DbType.Decimal);
            parameters.Add("@ModifiedOn", product.ModifiedOn, DbType.DateTime);
            parameters.Add("@AddedOn", product.AddedOn, DbType.DateTime);
        }
    }
}
