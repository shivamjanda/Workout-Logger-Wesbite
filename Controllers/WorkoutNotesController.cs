/*
 * Name: Shivam Janda
 * Date: December 12, 2022
 * Description: Workout Notes controller class 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5Workout.Data;
using Lab5Workout.Models;
using Microsoft.AspNetCore.Authorization;

namespace Lab5Workout.Controllers
{
    public class WorkoutNotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CaloriesBurneds
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkoutNotes.Include(c => c.exerciseID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CaloriesBurneds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caloriesBurned = await _context.WorkoutNotes
                .Include(c => c.exerciseID)
                .FirstOrDefaultAsync(m => m.wID == id);
            if (caloriesBurned == null)
            {
                return NotFound();
            }

            return View(caloriesBurned);
        }

        // GET: CaloriesBurneds/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["workoutID"] = new SelectList(_context.Workouts, "workoutID", "workoutID");
            return View();
        }

        // POST: CaloriesBurneds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("wID,description,workoutID")] WorkoutNotes caloriesBurned)
        {
            if (ModelState.IsValid)
            {
    
                _context.Add(caloriesBurned);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["workoutID"] = new SelectList(_context.Workouts, "workoutID", "workoutID", caloriesBurned.workoutID);
            return View(caloriesBurned);
        }

        // GET: CaloriesBurneds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caloriesBurned = await _context.WorkoutNotes.FindAsync(id);
            if (caloriesBurned == null)
            {
                return NotFound();
            }
            ViewData["workoutID"] = new SelectList(_context.Workouts, "workoutID", "workoutID", caloriesBurned.workoutID);
            return View(caloriesBurned);
        }

        // POST: CaloriesBurneds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("wID,description,workoutID")] WorkoutNotes caloriesBurned)
        {
            if (id != caloriesBurned.wID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caloriesBurned);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaloriesBurnedExists(caloriesBurned.wID))
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
            ViewData["workoutID"] = new SelectList(_context.Workouts, "workoutID", "workoutID", caloriesBurned.workoutID);
            return View(caloriesBurned);
        }

        // GET: CaloriesBurneds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caloriesBurned = await _context.WorkoutNotes
                .Include(c => c.exerciseID)
                .FirstOrDefaultAsync(m => m.wID == id);
            if (caloriesBurned == null)
            {
                return NotFound();
            }

            return View(caloriesBurned);
        }

        // POST: CaloriesBurneds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caloriesBurned = await _context.WorkoutNotes.FindAsync(id);
            _context.WorkoutNotes.Remove(caloriesBurned);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaloriesBurnedExists(int id)
        {
            return _context.WorkoutNotes.Any(e => e.wID == id);
        }

    
    }
}
