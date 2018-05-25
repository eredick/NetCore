using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface IOrderRepository: IRepository<Order>
    {
        IEnumerable<Order> PagedList(int startRow, int endRow);
        int Count();
        IEnumerable<Order> OrderByCustomer(int customerId);
    }
}
