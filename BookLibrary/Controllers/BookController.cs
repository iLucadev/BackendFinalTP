using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models.Domain;
using BookLibrary.Data.Repositories.Abstract;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IBookRepository _borrowRepository;
        public BookController(IRepository<Book> bookRepository, IBookRepository borrowRepository)
        {
            _bookRepository = bookRepository;
            _borrowRepository = borrowRepository;
        }


        // GET: Book
        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAll();
            return View(books);
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Guid,Title,Author,ISBN,Available")] Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookRepository.Insert(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Guid,Title,Author,ISBN,Available")] Book book)
        {
            if (id != book.Guid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookRepository.Update(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookViewModelExists(book.Guid))
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
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var book = await _bookRepository.GetById(id);
            if (book != null)
            {
                await _bookRepository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BookViewModelExists(Guid id)
        {
            var book = _bookRepository.GetById(id);
            return book != null;
        }
    }
}
