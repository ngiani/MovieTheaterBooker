using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTheaterBooker.Data;
using MovieTheaterBooker.Models;

namespace MovieTheaterBooker.Controllers
{
    public class ScreenReleasesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ScreenReleasesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: ScreenReleases
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScreenReleases.AsNoTracking().ToListAsync());
        }

        // GET: ScreenReleases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screenRelease = await _context.ScreenReleases
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screenRelease == null)
            {
                return NotFound();
            }

            return View(screenRelease);
        }

        // GET: ScreenReleases/Create
        public IActionResult Create(int? movieId)
        {
            if (movieId == null)
                return NotFound();

            var movie = _context.Movies.Find(movieId);

            if (movie == null)
                return NotFound();

            var screenRelease = new ScreenRelease
            {
                Movie = movie,
                MovieId = movie.Id
            };

            ViewData["ScreenId"] = new SelectList(_context.Screens, "Id", "Name");

            return View(screenRelease);
        }

        // POST: ScreenReleases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create([Bind("Id", "MovieId", "ScreenId", "ReleaseTime")]ScreenRelease screenRelease)
        {
            var movie = await _context.Movies.FindAsync(screenRelease.MovieId);
            var screen = await _context.Screens.FindAsync(screenRelease.ScreenId);

            screenRelease.Movie = movie;
            screenRelease.Screen = screen;

            if (await IsConflictAsync(screenRelease.Screen, screenRelease.Movie, screenRelease.ReleaseTime))
                ModelState.AddModelError(nameof(screenRelease.ReleaseTime), "Conflict: another release at the same time");


            if (ModelState.IsValid)
            {
                _context.Add(screenRelease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewData["ScreenId"] = new SelectList(_context.Screens, "Id", "Name", screenRelease.ScreenId);


            return View(screenRelease);
        }

        // GET: ScreenReleases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screenRelease = await _context.ScreenReleases.FindAsync(id);
            if (screenRelease == null)
            {
                return NotFound();
            }


            return View(screenRelease);
        }

        // POST: ScreenReleases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReleaseTime")] ScreenRelease screenRelease)
        {
            if (id != screenRelease.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currentRelease = await _context.ScreenReleases.
                        Include(s => s.Movie).
                        FirstOrDefaultAsync(s => s.Id == id);

                    if (currentRelease == null)
                    {
                        return NotFound();
                    }

                    currentRelease.ReleaseTime = screenRelease.ReleaseTime;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreenReleaseExists(screenRelease.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(screenRelease);
        }

        // GET: ScreenReleases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screenRelease = await _context.ScreenReleases
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screenRelease == null)
            {
                return NotFound();
            }

            return View(screenRelease);
        }

        // POST: ScreenReleases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var screenRelease = await _context.ScreenReleases.FindAsync(id);
            if (screenRelease != null)
            {
                _context.ScreenReleases.Remove(screenRelease);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        private bool ScreenReleaseExists(int id)
        {
            return _context.ScreenReleases.Any(e => e.Id == id);
        }

        /// <summary>
        /// Check whether the added release is conflicting with an existing release (same screen, same time)
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="movie"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        private async Task<bool> IsConflictAsync(Screen screen, Movie movie, DateTime startDate)
        {
            var endDate = startDate.AddMinutes(movie.Duration);

            // Optimize: Filter at database level and check for overlaps using SQL
            // A release conflicts if it overlaps with the new release time window
            var hasConflict = await _context.ScreenReleases
                .Where(r => r.Screen.Id == screen.Id)
                .Include(r => r.Movie)
                .AnyAsync(r => 
                    // The new release starts before this release ends
                    startDate < r.ReleaseTime.AddMinutes(r.Movie.Duration) &&
                    // The new release ends after this release starts
                    endDate > r.ReleaseTime);

            return hasConflict;
           
        }
    }
}
