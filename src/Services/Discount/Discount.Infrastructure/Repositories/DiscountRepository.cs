using Dapper;
using Discount.Infrastructure.Repositories.Interfaces;
using MicroservicesProject.Core.Entities.PostgreSQL;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private string _connectionString;

        public DiscountRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("DatabaseSettings:ConnectionString").Value;
        }

        public async Task<Coupon> GetDiscountAsync(string productName)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                (@"SELECT * FROM Coupon WHERE ProductName = @ProductName",
                 param: new
                 {
                     ProductName = productName
                 });

            return coupon;
        }

        public async Task<bool> CreateDiscountAsync(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var affected = await connection.ExecuteAsync
                (@"INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                param: coupon);

            return affected == 0 ? false : true;
        }

        public async Task<bool> UpdateDiscountAsync(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var affected = await connection.ExecuteAsync
                (@"UPDATE Coupon SET Description = @Description,
                                     Amount      = @Amount
                                 WHERE ProductName = @ProductName",
                param: coupon);

            return affected == 0 ? false : true;
        }

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var affected = await connection.ExecuteAsync
                (@"DELETE FROM Coupon WHERE ProductName = @ProductName",
                param: new
                {
                    ProductName = productName
                });

            return affected == 0 ? false : true;
        }
    }
}
