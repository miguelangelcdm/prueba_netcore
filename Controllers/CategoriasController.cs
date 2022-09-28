using Microsoft.AspNetCore.Mvc;
using webappBD.Datos;
using webappBD.Models;

namespace webappBD.Controllers
{
    public class CategoriasController : Controller
    {
        public readonly ApplicationDbContext _context;
        public CategoriasController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            List<Categoria> listaCategorias = _context.Categoria.ToList();
            return View(listaCategorias);
        }
        [HttpGet]
        public IActionResult Crear(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult crear(Categoria categoria){
            if(ModelState.IsValid){
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id){
            if (id==null)
            {
                return View();
            }
            var categoria=_context.Categoria.FirstOrDefault(c=>c.Categoria_Id==id);
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria categoria){
            if (ModelState.IsValid){
                _context.Categoria.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }
        [HttpGet]
        public IActionResult Borrar(int? id){
            var categoria=_context.Categoria.FirstOrDefault(c=>c.Categoria_Id==id);
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}