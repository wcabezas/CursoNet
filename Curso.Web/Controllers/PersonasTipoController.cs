using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Curso.DataAccess.Models;

namespace Curso.Web.Controllers
{
    public class PersonasTipoController : Controller
    {
        private readonly appcursoContext _context;

        public PersonasTipoController(appcursoContext context)
        {
            _context = context;
        }

        // GET: PersonasTipo
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonasTipo.ToListAsync());
        }

        // GET: PersonasTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasTipo = await _context.PersonasTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personasTipo == null)
            {
                return NotFound();
            }

            return View(personasTipo);
        }

        // GET: PersonasTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonasTipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] PersonasTipo personasTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personasTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personasTipo);
        }

        // GET: PersonasTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasTipo = await _context.PersonasTipo.FindAsync(id);
            if (personasTipo == null)
            {
                return NotFound();
            }
            return View(personasTipo);
        }

        // POST: PersonasTipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] PersonasTipo personasTipo)
        {
            if (id != personasTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personasTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasTipoExists(personasTipo.Id))
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
            return View(personasTipo);
        }

        // GET: PersonasTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personasTipo = await _context.PersonasTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personasTipo == null)
            {
                return NotFound();
            }

            return View(personasTipo);
        }

        // POST: PersonasTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personasTipo = await _context.PersonasTipo.FindAsync(id);
            _context.PersonasTipo.Remove(personasTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonasTipoExists(int id)
        {
            return _context.PersonasTipo.Any(e => e.Id == id);
        }
    }
}
