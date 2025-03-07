using DevWeb0306.Data;
using DevWeb0306.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DevWeb0306.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.TotalEixos = _context.Eixo.Count();
            ViewBag.TotalCursos = _context.Curso.Count();
            ViewBag.TotalMaterias = _context.Materia.Count();
            ViewBag.TotalProfessores = _context.Professor.Count();
            if (_context.Professor.Any())
            {
                ViewBag.UltimoProfessor = _context.Professor.OrderByDescending(x => x.Id).FirstOrDefault().Nome;
            } else
            {
                ViewBag.UltimoProfessor = "Nenhum";
            }
            if (_context.Curso.Any())
            {
                ViewBag.UltimoCurso = _context.Curso.OrderByDescending(x => x.Id).FirstOrDefault().Nome;
            } else
            {
                ViewBag.UltimoCurso = "Nenhum";
            }
            if (_context.Materia.Any())
            {
                ViewBag.UltimaMateria = _context.Materia.OrderByDescending(x => x.Id).FirstOrDefault().Nome;
            } else
            {
                ViewBag.UltimaMateria = "Nenhuma";
            }

            var cursos = _context.Curso
                .OrderByDescending(c => c.Id)  // Assumindo que Id é a chave primária e representa a ordem de criação
                .Take(5)
                .Include(x => x.Eixo)
                .ToList();

            return View(cursos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
