using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HotelTamagotchi.Domain.Repository;
using HotelTamagotchi.Models.ViewModel;

namespace HotelTamagotchi.Controllers
{
    //  [Authorize]
    public class HotelRoomsController : Controller
    {

        private readonly HotelRoomRepository _hotelRoomRepository;
        private readonly HotelRoomTypeRepository _hotelRoomTypeRepository;
        private readonly HotelRoomSizeRepository _hotelRoomSizeRepository;

        public HotelRoomsController(
            HotelRoomRepository hotelRoomRepository,
            HotelRoomTypeRepository hotelRoomTypeRepository,
            HotelRoomSizeRepository hotelRoomSizeRepository
            )
        {
            this._hotelRoomRepository = hotelRoomRepository;
            this._hotelRoomTypeRepository = hotelRoomTypeRepository;
            this._hotelRoomSizeRepository = hotelRoomSizeRepository;
        }


        // GET: HotelRooms
        public ActionResult Index()
        {
            List<HotelRoomVM> hotelRooms = _hotelRoomRepository.GetAll().Select(h => new HotelRoomVM(h)).ToList();

            return View(hotelRooms);
        }

        // GET: HotelRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hotelRoom = new HotelRoomVM(_hotelRoomRepository.GetWhereId(id));
            if (hotelRoom == null)
            {
                return HttpNotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRooms/Create
        public ActionResult Create()
        {
            ViewBag.RoomSize = new SelectList(_hotelRoomSizeRepository.GetAll(), "RoomSize", "RoomSize");
            ViewBag.RoomType = new SelectList(_hotelRoomTypeRepository.GetAll(), "RoomType", "RoomType");
            var hotelRoomVM = new HotelRoomVM();
            
            return View(hotelRoomVM);
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelRoomVM hotelRoomVM)
        {
            if (ModelState.IsValid)
            {
                _hotelRoomRepository.Add(hotelRoomVM.ToModel());
                return RedirectToAction("Index");
            }
            ViewBag.RoomSize = new SelectList(_hotelRoomSizeRepository.GetAll(), "RoomSize", "RoomSize", hotelRoomVM.RoomSize);
            ViewBag.RoomType = new SelectList(_hotelRoomTypeRepository.GetAll(), "RoomType", "RoomType", hotelRoomVM.RoomType);
        
            return View(hotelRoomVM);
        }

        // GET: HotelRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var hotelRoomVM = new HotelRoomVM(_hotelRoomRepository.GetWhereId(id));
            if (hotelRoomVM == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomSize = new SelectList(_hotelRoomSizeRepository.GetAll(), "RoomSize", "RoomSize", hotelRoomVM.RoomSize);
            ViewBag.RoomType = new SelectList(_hotelRoomTypeRepository.GetAll(), "RoomType", "RoomType", hotelRoomVM.RoomType);

            return View(hotelRoomVM);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelRoomVM hotelRoomVM)
        {
            if (ModelState.IsValid)
            {
                _hotelRoomRepository.Edit(hotelRoomVM.ToModel());
                return RedirectToAction("Index");
            }
            ViewBag.RoomSize = new SelectList(_hotelRoomSizeRepository.GetAll(), "RoomSize", "RoomSize", hotelRoomVM.RoomSize);
            ViewBag.RoomType = new SelectList(_hotelRoomTypeRepository.GetAll(), "RoomType", "RoomType", hotelRoomVM.RoomType);

            return View(hotelRoomVM);
        }

        // GET: HotelRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (_hotelRoomRepository.GetAll().Count > 4)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var hotelRoomVM = new HotelRoomVM(_hotelRoomRepository.GetWhereId(id));
                if (hotelRoomVM == null)
                {
                    return HttpNotFound();
                }
                return View(hotelRoomVM);
            }

            return RedirectToAction("Index");
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var hotelRoomVM = new HotelRoomVM(_hotelRoomRepository.GetWhereId(id));
            _hotelRoomRepository.Delete(hotelRoomVM.ToModel());

            return RedirectToAction("Index");
        }
    }
}
