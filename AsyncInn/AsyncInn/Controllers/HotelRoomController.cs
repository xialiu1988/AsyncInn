using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: HotelRoom
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel).Include(h => h.Room);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: HotelRoom/Details/5
        public async Task<IActionResult> Details(int? roomnumber,int? hotelid)
        {
            if (hotelid == null||roomnumber==null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(h => h.Hotel)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HotelID == hotelid && m.RoomNumber==roomnumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRoom/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name");
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name");
            return View();
        }

        // POST: HotelRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRoom/Edit/5
        public async Task<IActionResult> Edit(int? roomnumber, int? hotelid)
        {
            if (hotelid == null||roomnumber==null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .FirstOrDefaultAsync(hr => hr.RoomNumber == roomnumber && hr.HotelID == hotelid);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // POST: HotelRoom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int hotelid,int roomnumber, [Bind("HotelID,RoomNumber,RoomID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (roomnumber != hotelRoom.RoomNumber || hotelid != hotelRoom.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists( hotelRoom.RoomNumber,hotelRoom.HotelID))
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
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "Name", hotelRoom.HotelID);
            ViewData["RoomID"] = new SelectList(_context.Rooms, "ID", "Name", hotelRoom.RoomID);
            return View(hotelRoom);
        }

        // GET: HotelRoom/Delete/5
        public async Task<IActionResult> Delete(int? roomnumber, int? hotelid)
        {
            if (roomnumber == null || hotelid == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .Include(r => r.Room)
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.RoomNumber == roomnumber && m.HotelID==hotelid);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int roomnumber,int hotelid)
        {
            var hotelRoom = await _context.HotelRooms
               .FirstOrDefaultAsync(hr => hr.RoomNumber == roomnumber && hr.HotelID == hotelid);
            _context.HotelRooms.Remove(hotelRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int roomnumber,int hotelid)
        {
            return _context.HotelRooms.Any(e=>e.RoomNumber==roomnumber && e.HotelID==hotelid);
        }
    }
}
