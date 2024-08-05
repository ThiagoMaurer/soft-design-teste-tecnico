using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftDesignTesteTecnico.Database;

[Authorize]
public class BooksController : Controller
{
    private readonly ApplicationDbContext _context;

    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string searchString)
    {
        var books = from b in _context.Books
                    select b;

        if (!String.IsNullOrEmpty(searchString))
        {
            books = books.Where(s => s.Title.Contains(searchString));
            ViewData["CurrentFilter"] = searchString;
        }

        return View(await books.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books
            .FirstOrDefaultAsync(m => m.Id == id);

        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    public async Task<IActionResult> Rent(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books.FindAsync(id);
        if (book == null || book.IsRented)
        {
            return NotFound();
        }

        book.IsRented = true;
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
