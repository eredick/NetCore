using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibertec.Models;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Cibertec.Web.Controllers
{
    [Route("api/customer")]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit) : base(unit)
        {
        }
        public IActionResult GetList()
        {
            return Ok(_unit.Customers.GetList());
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Customers.GetById(id));
        }
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_unit.Customers.Insert(customer));
        }
        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            if (!ModelState.IsValid && _unit.Customers.Update(customer))
                return Ok(new { Mensaje = "Se actualizó correctamente"});

            return BadRequest(ModelState);            
        }
        [Route("list/{page}/{rows}")]
        public IActionResult GetCount(int page, int rows)
        {
            var start = ((page - 1) * rows) - 1;
            var end = page * rows;
            return Ok(_unit.Customers.PagedList(start, end));
        }
    }
}
