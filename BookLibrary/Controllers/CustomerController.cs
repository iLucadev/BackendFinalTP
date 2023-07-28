using BookLibrary.Models.Domain;
using BookLibrary.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: Customer
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomers();
            return View(customers);
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(Guid? customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }

            var customer= await _customerService.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Guid,FirstName,LastName,Phone,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.CreateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Guid,FirstName,LastName,Phone,Email")] Customer customer)
        {
            if (id != customer.Guid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _customerService.UpdateCustomer(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookViewModelExists(customer.Guid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            if (customer.BookCustomers.Any())
            {
                var borrowed = new List<string>();
                customer.BookCustomers.ToList().ForEach(bookCustomer =>
                {
                    borrowed.Add(bookCustomer.Book.Title);
                });

                return BadRequest("Cannot delete customer. The following books are borrowed: " + string.Join(", ", borrowed));
            }

            await _customerService.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BookViewModelExists(Guid id)
        {
            var book = _customerService.GetCustomerById(id);
            return book != null;
        }

    }
}
