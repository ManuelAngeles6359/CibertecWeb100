using Microsoft.AspNetCore.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Models;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {

        private readonly IUnitOfWork _unit;

        public CustomerController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult GetList()
        {
            return Ok(_unit.Customers.GetList());
        }


        public IActionResult GetById(int id)
        {
            return Ok(_unit.Customers.GetById(id));
        }

    }
}