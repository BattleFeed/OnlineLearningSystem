using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLearningSystem.Data;

namespace OnlineLearningSystem.Models
{
    public class ProblemsController : Controller
    {
        private readonly UserContext _context;

        public ProblemsController(UserContext context)
        {
            _context = context;
        }

        // GET: Problems
        //public async Task<IActionResult> Index()
        //{
        //    var userContext = _context.Problems.Include(p => p.Section);
        //    return View(await userContext.ToListAsync());
        //}

        // GET: Problems/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var problem = await _context.Problems
        //        .Include(p => p.Section)
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (problem == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(problem);
        //}

        // GET: Problems/Create/5
        // The id here represents SectionID
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //ViewData["SectionID"] = new SelectList(_context.Sections, "ID", "ID");
            ViewData["SectionID"] = id;
            return View();
        }

        // POST: Problems/Create/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("Score,Description,Choice1,Choice2,Choice3,Choice4,CorrectChoiceID")] Problem problem)
        {
            if (id == null)
            {
                return NotFound();
            }
            problem.SectionID = Convert.ToInt32(id);
            if (ModelState.IsValid)
            {
                _context.Add(problem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Problems", "Sections", new { id = id });
            }
            //ViewData["SectionID"] = new SelectList(_context.Sections, "ID", "ID", problem.SectionID);
            ViewData["SectionID"] = id;
            return View(problem);
        }

        // GET: Problems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }
            //ViewData["SectionID"] = new SelectList(_context.Sections, "ID", "ID", problem.SectionID);
            ViewData["SectionID"] = problem.SectionID;
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SectionID,Score,Description,Choice1,Choice2,Choice3,Choice4,CorrectChoiceID")] Problem problem)
        {
            if (id != problem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemExists(problem.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Problems", "Sections", new { id = problem.SectionID});
            }
            //ViewData["SectionID"] = new SelectList(_context.Sections, "ID", "ID", problem.SectionID);
            ViewData["SectionID"] = problem.SectionID;
            return View(problem);
        }

        // GET: Problems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems
                .Include(p => p.Section)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var problem = await _context.Problems.FindAsync(id);
            int sectionID = problem.SectionID;
            _context.Problems.Remove(problem);
            await _context.SaveChangesAsync();
            return RedirectToAction("Problems", "Sections", new { id = sectionID });
        }

        private bool ProblemExists(int id)
        {
            return _context.Problems.Any(e => e.ID == id);
        }
    }
}
