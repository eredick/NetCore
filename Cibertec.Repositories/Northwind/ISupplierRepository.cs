using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Northwind
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> PagedList(int startRow, int endRow);

        int Count();
    }
}
