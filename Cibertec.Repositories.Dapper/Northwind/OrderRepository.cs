using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString)
        {

        }

        public int Count()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>("SELECT Count(Id) FROM dbo.[Order]");
            }
        }

        public IEnumerable<Order> OrderByCustomer(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId);                
                return connection.Query<Order>(
                    "dbo.OrderByCustomer",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }

        public IEnumerable<Order> PagedList(int startRow, int endRow)
        {
            if (startRow >= endRow) return new List<Order>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@startRow", startRow);
                parameters.Add("@endRow", endRow);
                return connection.Query<Order>(
                    "dbo.OrderPagedList",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }
        }
    }
}
