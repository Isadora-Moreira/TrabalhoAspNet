using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoASPNet.Models;

namespace TrabalhoAspNet.Controllers
{
    public class LivrosController : Controller
    {
        private readonly Contexto _context;

        public LivrosController(Contexto context)
        {
            _context = context;
        }

        // GET: Livros
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Livros.Include(l => l.Autor).Include(l => l.Editora).Include(l => l.Genero);
            return View(await contexto.ToListAsync());
        }

        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Editora)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome");
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "Id", "Nome");
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Descricao");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,AnoPublicacao,Preco,QuantidadeEmEstoque,AutorId,GeneroId,EditoraId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome", livro.AutorId);
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "Id", "Nome", livro.EditoraId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Descricao", livro.GeneroId);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome", livro.AutorId);
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "Id", "Nome", livro.EditoraId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Descricao", livro.GeneroId);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,AnoPublicacao,Preco,QuantidadeEmEstoque,AutorId,GeneroId,EditoraId")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
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
            ViewData["AutorId"] = new SelectList(_context.Autores, "Id", "Nome", livro.AutorId);
            ViewData["EditoraId"] = new SelectList(_context.Editoras, "Id", "Nome", livro.EditoraId);
            ViewData["GeneroId"] = new SelectList(_context.Generos, "Id", "Descricao", livro.GeneroId);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Editora)
                .Include(l => l.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}
