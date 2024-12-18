using Microsoft.AspNetCore.Mvc;

namespace ${{values.name}}.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private static readonly List<Customer> customers = new List<Customer>
        {
            new Customer { id = 1001, name = "Contoso", edited = DateTime.Now },
            new Customer { id = 1002, name = "Northwind", edited = DateTime.Now }
        };

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCustomers")]
        public List<Customer> GetCustomers()
        {
            return customers;
        }

        [HttpGet(Name = "GetCustomer")]
        public Customer GetCustomer(int id)
        {
            return customers.FirstOrDefault(c => c.id == id);
        }

        [HttpPost(Name = "AddCustomer")]
        public Customer AddCustomer(Customer customer)
        {
            customers.Add(customer);
            return customer;
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public ActionResult DeleteCustomer(int id)
        {
            customers.Remove(customers.FirstOrDefault(c=>c.id==id));
            return Ok($"Customer {id} deleted.");

        }
    }
}
