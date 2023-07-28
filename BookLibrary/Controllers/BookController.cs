using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibrary.Models.Domain;
using BookLibrary.Services.Abstract;
using System.Net;

namespace BookLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        // GET: Book
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooks();
            return View(books);
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(Guid Id)
        {
            var book = await _bookService.GetBookById(Id);
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
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(Guid Id)
        {
            var book = await _bookService.GetBookById(Id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid Id, Book book)
        {
            if (Id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.UpdateBook(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookViewModelExists(book.Id))
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
        public async Task<IActionResult> Delete(Guid Id)
        {
            var book = await _bookService.GetBookById(Id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid Id)
        {
            var book = await _bookService.GetBookById(Id);
            if (book == null)
            {
                return NotFound();
            }

            if (book.IsBorrowed)
            {
                return BadRequest("Book is on loan.");
            }

            await _bookService.DeleteBook(Id);
            return RedirectToAction(nameof(Index));
        }

        private bool BookViewModelExists(Guid Id)
        {
            var book = _bookService.GetBookById(Id);
            return book != null;
        }
    }
}
