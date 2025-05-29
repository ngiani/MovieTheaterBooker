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
    public class ScreensController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ScreensController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Screens
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Screens.ToListAsync());
        }*/

        // GET: Screens/Details/5
        /// <summary>
        /// Get simple view of screen
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screen = await _context.Screens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screen == null)
            {
                return NotFound();
            }

            return View(screen);
        }


        /// <summary>
        /// Get View of screen with bookable seats at specific release
        /// </summary>
        /// <param name="id"></param>
        /// <param name="releaseId"></param>
        /// <returns></returns>
        [HttpGet("{id}/{releaseId}")]
        public async Task<IActionResult> Details(int? id, int? releaseId)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (releaseId == null)
            {
                return NotFound();
            }

            var screen = await _context.Screens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screen == null)
            {
                return NotFound();
            }

            ScreenAtReleaseVM screenAtRelease = _mapper.Map<ScreenAtReleaseVM>(screen);


            var screenRelease = await _context.ScreenReleases.
                        Include(r => r.Screen).
                        Include(r => r.Movie).
                        FirstOrDefaultAsync(r => r.Id == releaseId);

            if (screenRelease == null)
            {
                return NotFound();
            }

            var seats = await _context.Seats.
                Where(s => s.Screen.Id == id).
                ToListAsync();

            var bookings = await _context.SeatsBooking.
                Where(b => b.ScreenRelease.Id == releaseId).
                ToListAsync();

            screenAtRelease.Name = screen.Name;
            screenAtRelease.Seats = seats;
            screenAtRelease.ScreenRelease = screenRelease;
            screenAtRelease.SeatBookings = bookings;

            return View(screenAtRelease);
        }


        // GET: Screens/Create
        /*public IActionResult Create()
        {
            return View();
        }

        // POST: Screens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Screen screen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(screen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(screen);
        }

        // GET: Screens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screen = await _context.Screens.FindAsync(id);
            if (screen == null)
            {
                return NotFound();
            }
            return View(screen);
        }

        // POST: Screens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Screen screen)
        {
            if (id != screen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreenExists(screen.Id))
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
            return View(screen);
        }

        // GET: Screens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screen = await _context.Screens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screen == null)
            {
                return NotFound();
            }

            return View(screen);
        }

        // POST: Screens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var screen = await _context.Screens.FindAsync(id);
            if (screen != null)
            {
                _context.Screens.Remove(screen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool ScreenExists(int id)
        {
            return _context.Screens.Any(e => e.Id == id);
        }
    }
}
