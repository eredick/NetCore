using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Northwind
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> PagedList(int startRow, int endRow);

        int Count();
    }
}
