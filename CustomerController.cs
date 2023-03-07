using costumer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace costumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        List<Customer> _customers;

        public CustomerController()
        {
            _customers = new List<Customer>() { new Customer() { Id = 1, name = "Abel", email = "Abel@gmail.com" },
                new Customer() { Id = 2, name = "EJ", email = "EJ@gmail.com" },
                new Customer() { Id = 3, name = "Elli", email = "Elli@gmail.com" },
                new Customer() { Id = 4, name = "Ivan", email = "Ivan@gmail.com" }

            };
        }
        [HttpGet]
        [Route("GetAllCustomer")]
        public ActionResult<List<Customer>> GetCustomer()
        {
            return Ok(_customers);

        }

        [HttpGet]
        [Route("GetCustomerById/{id:int}")]
        public ActionResult<Customer> GetCustomerByID(int id)
        {
            if (id == 200)

                return NotFound();

            else

            {
                Customer customer = _customers.Find(p => p.Id == id);

                return Ok(customer);

            }
        }

        [HttpGet]
        [Route("CustomerByName/{name:alpha}")]
        public ActionResult<Customer> GetCustomerByName(string name)
        {
            if (name == null)

                return NotFound();

            else

            {
                Customer customer = _customers.Find(p => p.name == name);

                return Ok(customer);

            }

        }


        [HttpPost]
        [Route("AddCustomer")]
        public ActionResult<Customer> StoreCustomer(Customer customer)
        {
            _customers.Add(customer);

            return Ok(customer);
        }

        [HttpDelete]
        [Route("DeleteCustomer/{id:int}")]
        public ActionResult<Customer> RemoveCustomer(int id)
        {
            try
            {
                var result = _customers.Remove(_customers.Find(p => p.Id == id));

                return Ok(_customers);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
    
}
