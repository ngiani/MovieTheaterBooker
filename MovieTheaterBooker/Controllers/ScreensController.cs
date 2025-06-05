using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTheaterBooker.Data;
using MovieTheaterBooker.HTTPExtensions;
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
        [HttpGet("Screens/Details/{id}")]
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
        [HttpGet("Screens/Details/{id}/{releaseId}")]
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
                Include(s => s.Seat).
                Where(b => b.ScreenRelease.Id == releaseId).
                ToListAsync();

            screenAtRelease.Name = screen.Name;
            screenAtRelease.Seats = seats;
            screenAtRelease.ScreenRelease = screenRelease;
            screenAtRelease.SeatBookings = bookings;

            return View(screenAtRelease);
        }


        [HttpPost]
        public async Task<IActionResult> ToggleSeat([FromBody] SeatToggleDTO dto)
        {
            // Get temp booking list from session as list of seats IDs
            var bookedSeatsIDS = HttpContext.Session.GetObjectFromJson<List<int>>("bookedSeatsIDS") ?? new List<int>();

           


            //Check if toggle is selected
            if (dto.Selected)
            {
                // Add new booking on temp list if does not exist in it
                if (!bookedSeatsIDS.Any(s => s == dto.Id))
                {
                    bookedSeatsIDS.Add(dto.Id);
                }
            }

            //Remove booking if unchecked
            else
            {
                bookedSeatsIDS.RemoveAll(s => s == dto.Id);
            }

            //Save temp list in session
            HttpContext.Session.SetObjectAsJson("bookedSeatsIDS", bookedSeatsIDS);

            return Ok();
        }

        //Buy tickets at the specified screen release, from bookings in temporary list 
        [HttpPost("Buy/{releaseId}")]
        public async Task<IActionResult> Buy(int? releaseId)
        {
            // Get temp booking list from session as list of seats IDs
            var bookedSeatsIDS = HttpContext.Session.GetObjectFromJson<List<int>>("bookedSeatsIDS") ?? new List<int>();

            var seats = await _context.Seats.Include(s => s.Screen).ToListAsync();
            var releases = await _context.ScreenReleases.Include(s => s.Movie).Include(s => s.Screen).ToListAsync();


            foreach (var seatID in bookedSeatsIDS)
            {
                //Create a seat booking from seat ID
                SeatBooking seatBooking = new SeatBooking();

                //Geat seat from Id
                var seat = seats.FirstOrDefault(s => s.Id == seatID);

                //Geat screen release from Id 
                var release = releases.FirstOrDefault(s => s.Id == releaseId);

                seatBooking.Seat = seat;
                seatBooking.ScreenRelease = release;


                //Save to db 
                _context.Add(seatBooking);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Confirmed", "Screens");


        }

        //Bookings confirm view (show booking from previous list)
        public async Task<IActionResult> Confirmed()
        {
            // Get temp booking list from session as list of seats IDs
            var bookedSeatsIDS = HttpContext.Session.GetObjectFromJson<List<int>>("bookedSeatsIDS") ?? new List<int>();


            //Get bookings from Db
            var bookings = await _context.SeatsBooking.Include(s => s.Seat).
                Include(s => s.ScreenRelease).
                Include(s => s.ScreenRelease.Movie).
                Include(s => s.ScreenRelease.Screen).ToListAsync();


            //Filter list of bookings with seat IDs specified in temp list
            var currentBookings = bookings.FindAll(b => bookedSeatsIDS.Contains(b.Seat.Id));

            //Model view with filtered bookings
            ConfirmedBookingVM confirmedBookingVM = new ConfirmedBookingVM();
            confirmedBookingVM.SeatBookings = currentBookings;

            HttpContext.Session.Remove("bookedSeatsIDS");

            return View("Confirmed", confirmedBookingVM);
        }


        /// <summary>
        /// Intercept cancel booking action (going to a different page without completing the process)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CancelBooking()
        {
            HttpContext.Session.Remove("bookedSeatsIDS");
            return Ok();
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
