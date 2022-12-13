/*
 * Name: Shivam Janda
 * Date: December 12, 2022
 * Description: Workouts controller class 
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
    public class WorkoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkoutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Workouts
        public async Task<IActionResult> Index()
        {

            return View(await _context.Workouts.ToListAsync());
        }

        // GET: Workouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return View("FailureScreen");
            }

            var workout = await _context.Workouts
                .FirstOrDefaultAsync(m => m.workoutID == id);
            if (workout == null)
            {
                return View("FailureScreen"); ;
            }

            return View(workout);
        }

        // GET: Workouts/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("workoutID,workoutName,sets,reps,notes")] Workout workout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workout);
        }

        // GET: Workouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return View("FailureScreen"); // return the faliure screen view
            }

            var workout = await _context.Workouts.FindAsync(id);
            if (workout == null)
            {
                return View("FailureScreen");
            }
            return View(workout);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("workoutID,workoutName,sets,reps,notes")] Workout workout)
        {
            if (id != workout.workoutID)
            {
                return View("FailureScreen");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutExists(workout.workoutID))
                    {
                        return View("FailureScreen");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(workout);
        }

        // GET: Workouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return View("FailureScreen");
            }

            var workout = await _context.Workouts
                .FirstOrDefaultAsync(m => m.workoutID == id);
            if (workout == null)
            {
                return View("FailureScreen");
            }

            return View(workout);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workout = await _context.Workouts.FindAsync(id);
            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutExists(int id)
        {
            return _context.Workouts.Any(e => e.workoutID == id);
        }

    }
}
