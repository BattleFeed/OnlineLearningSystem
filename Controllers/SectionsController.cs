using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineLearningSystem.Data;
using OnlineLearningSystem.Models;
using OnlineLearningSystem.ViewModels;

namespace OnlineLearningSystem.Controllers
{
    public class SectionsController : Controller
    {
        private readonly UserContext _context;

        public SectionsController(UserContext context)
        {
            _context = context;
        }

        // GET: Sections
        //public async Task<IActionResult> Index()
        //{
        //    var userContext = 
        //        _context.Sections.Include(s => s.Course);
            
        //    return View(await userContext.ToListAsync());
        //}

        // GET: Sections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // GET: Sections/Problems/5
        public async Task<IActionResult> Problems(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.ProblemSet)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (section == null)
            {
                return NotFound();
            }

            var pvmList = new List<ProblemVM>();
            foreach (var problem in section.ProblemSet)
            {
                var pvm = new ProblemVM { Problem = problem, ID = problem.ID, CorrectAnswer = problem.CorrectChoiceID, Score = problem.Score };
                pvmList.Add(pvm);
            }
            var vm = new ProblemPageVM { SectionID = Convert.ToInt32(id), Problems = pvmList};

            return View(vm);
        }

        // POST: Sections/Problems/5
        [HttpPost]
        public async Task<IActionResult> Problems(ProblemPageVM vm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            int score = 0;
            int historyScore = 0;
            int correctCount = 0;
            foreach (var problem in vm.Problems)
            {
                if (problem.SelectedAnswer == null)
                {
                    continue;
                }
                if (problem.SelectedAnswer == problem.CorrectAnswer)
                {
                    score += problem.Score;
                    correctCount++;
                }
            }

            var history = await _context.UserScoreHistories
                .FirstOrDefaultAsync(u => u.SectionID == vm.SectionID && u.UserId == userId);
            if (history == null)
            {
                _context.UserScoreHistories.Add(new UserScoreHistory { UserId = userId, SectionID = vm.SectionID, HighScore = score });
                currentUser.Score += score;
            }
            else
            {
                historyScore = history.HighScore;
                history.HighScore = Math.Max(historyScore, score);
                _context.Update(history);
                currentUser.Score += (score > historyScore) ? (score - historyScore) : 0;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Result", new { score = score, historyScore = historyScore, correctCount = correctCount, sectionID = vm.SectionID});
        }

        // GET: Sections/Result
        public IActionResult Result(int score, int historyScore, int correctCount,int sectionID)
        {
            ViewData["Score"] = score;
            ViewData["HistoryScore"] = historyScore;
            ViewData["SectionID"] = sectionID;
            ViewData["CorrectCount"] = correctCount;
            return View();
        }

        // GET: Sections/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "Name");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("CourseID,Name,Intro,Content")] Section section)
        {
            var courseSections = _context.Sections.Where(s => s.CourseID == section.CourseID);
            if (courseSections.Any())
            {
                section.SectionID = courseSections.Max(s => s.SectionID) + 1;
            }
            else
            {
                section.SectionID = 1;
            }

            if (ModelState.IsValid)
            {
                _context.Add(section);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Courses", new { id = section.CourseID});
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "ID", "Name", section.CourseID);
            return View(section);
        }

        // GET: Sections/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Course)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CourseID,SectionID,Name,Intro,Content")] Section section)
        {
            if (id != section.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(section);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectionExists(section.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Courses", new { id = section.CourseID});
            }
            return View(section);
        }

        // GET: Sections/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _context.Sections
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (section == null)
            {
                return NotFound();
            }

            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Courses", new { id = section.CourseID});
        }

        private bool SectionExists(int id)
        {
            return _context.Sections.Any(e => e.ID == id);
        }
    }
}
