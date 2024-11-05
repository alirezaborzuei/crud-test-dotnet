using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
     [Route("api/[controller]")]
     [ApiController]

    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            // ValidMobilePhoneNumber
            if (!IsValidMobilePhoneNumber(customer.PhoneNumber))
            {
                return BadRequest("Invalid phone number. It must be a valid mobile number.");
            }

            // uniqe email
            if (await _context.Customers.AnyAsync(c => c.Email == customer.Email))
            {
                return BadRequest("Email must be unique.");
            }

            if (await _context.Customers.AnyAsync(c =>
                c.FirstName == customer.FirstName &&
                c.LastName == customer.LastName &&
                c.DateOfBirth == customer.DateOfBirth))
            {
                return BadRequest("Customer must be unique by Firstname, Lastname, and DateOfBirth.");
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // PUT: api/customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            // Validation Phone Number
            if (!IsValidMobilePhoneNumber(customer.PhoneNumber))
            {
                return BadRequest("Invalid phone number. It must be a valid mobile number.");
            }

            _context.Entry(customer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        private bool IsValidMobilePhoneNumber(string phoneNumber)
        {
            var phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var number = phoneUtil.Parse(phoneNumber, "IR"); // کد کشور را به نیاز خود تغییر دهید
                return phoneUtil.IsValidNumberForRegion(number, "IR") && phoneUtil.GetNumberType(number) == PhoneNumberType.MOBILE;
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}
