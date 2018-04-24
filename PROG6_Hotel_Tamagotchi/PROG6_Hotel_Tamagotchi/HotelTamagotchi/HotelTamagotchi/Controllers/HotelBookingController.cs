using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HotelTamagotchi.Domain.Repository;
using HotelTamagotchi.Models.ViewModel;
using HotelTamagotchi.Models.RoomFactory;

namespace HotelTamagotchi.Controllers
{
    public class HotelBookingController : Controller
    {
        private readonly HotelBookingRepository _hotelBookingRepository;
        private readonly HotelRoomRepository _hotelRoomRepository;
        private readonly TamagotchiRepository _tamagotchiRepository;
        private readonly RoomFactory _roomFactory;

        public HotelBookingController(
            HotelBookingRepository hotelBookingRepository,
            HotelRoomRepository hotelRoomRepository,
            TamagotchiRepository tamagotchiRepository,
            RoomFactory roomFactory)
        {
            this._hotelBookingRepository = hotelBookingRepository;
            this._hotelRoomRepository = hotelRoomRepository;
            this._tamagotchiRepository = tamagotchiRepository;
            this._roomFactory = roomFactory;
        }

        public HotelBookingController(
            HotelBookingRepository hotelBookingRepository,
            HotelRoomRepository hotelRoomRepository,
            TamagotchiRepository tamagotchiRepository)
        {
            this._hotelBookingRepository = hotelBookingRepository;
            this._hotelRoomRepository = hotelRoomRepository;
            this._tamagotchiRepository = tamagotchiRepository;
        }

        // GET: HotelBookings
        public ActionResult Index()
        {
            ViewBag.AmountOfTamagotchisLeft = _tamagotchiRepository.GetAllTamagotchisALiveAndNoHotelRoom().Count();
            ViewBag.AmountOfHotelRoomsLeft = _hotelRoomRepository.GetAllHotelRoomsWhereBookingIsNull().Count();

            List<HotelBookingVM> hotelBookingsVM = _hotelBookingRepository.GetAll().Select(h => new HotelBookingVM(h)).ToList();
            return View(hotelBookingsVM);
        }

        // GET: HotelBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelBookingVM hotelBookingVM = new HotelBookingVM(_hotelBookingRepository.GetWhereId(id));
            if (hotelBookingVM == null)
            {
                return HttpNotFound();
            }
            return View(hotelBookingVM);
        }


        public ActionResult Create()
        {

            var hotelRoomsWithOutBooking = this._hotelRoomRepository.GetAllHotelRoomsWhereBookingIsNull();
            var tamagotchi = this._tamagotchiRepository.GetAllTamagotchisALiveAndNoHotelRoom();

            if (hotelRoomsWithOutBooking.Count() > 0 && tamagotchi.Count() > 0)
            {
                var hotelBookingVM = new HotelBookingVM();

                ViewBag.HotelRoomId = new SelectList(hotelRoomsWithOutBooking, "HotelRoomId", "HotelRoomName");
                ViewBag.TamagotchisIds = new MultiSelectList(tamagotchi, "TamagotchiId", "Name");

                return View(hotelBookingVM);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelBookingVM hotelBookingVM)
        {
            this.CheckIfYouCanBookRoom(hotelBookingVM);

            if (ModelState.IsValid)
            {
                _hotelBookingRepository.Add(hotelBookingVM.ToModel());
                ChangeTamagotchiHotelRoom(hotelBookingVM);
                return RedirectToAction("Index");
            }

            var hotelRoomsWithOutBooking = this._hotelRoomRepository.GetAllHotelRoomsWhereBookingIsNull();
            ViewBag.HotelRoomId = new SelectList(hotelRoomsWithOutBooking, "HotelRoomId", "HotelRoomName", hotelBookingVM.HotelRoomId);

            var tamagotchi = this._tamagotchiRepository.GetAllTamagotchisALiveAndNoHotelRoom();
            ViewBag.TamagotchisIds = new MultiSelectList(tamagotchi, "TamagotchiId", "Name", hotelBookingVM.TamagotchisIds);

            return View(hotelBookingVM);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HotelBookingVM hotelBookingVM = new HotelBookingVM(_hotelBookingRepository.GetWhereId(id));
            _hotelBookingRepository.SetAllTamagotchiHotelRoomToNull(hotelBookingVM.ToModel());

            if (hotelBookingVM == null)
            {
                return HttpNotFound();
            }

            var tamagotchi = this._tamagotchiRepository.GetAllTamagotchisALiveAndNoHotelRoom();
            ViewBag.TamagotchisIds = new MultiSelectList(tamagotchi, "TamagotchiId", "Name", hotelBookingVM.TamagotchisIds);

            return View(hotelBookingVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HotelBookingVM hotelBookingVM)
        {

            this.CheckIfYouCanBookRoom(hotelBookingVM);

            if (ModelState.IsValid)
            {
                _hotelBookingRepository.Edit(hotelBookingVM.ToModel());
                ChangeTamagotchiHotelRoom(hotelBookingVM);
                return RedirectToAction("Index");
            }

            var tamagotchi = this._tamagotchiRepository.GetAllTamagotchisALiveAndNoHotelRoom();
            ViewBag.TamagotchisIds = new MultiSelectList(tamagotchi, "TamagotchiId", "Name", hotelBookingVM.TamagotchisIds);

            hotelBookingVM = new HotelBookingVM(_hotelBookingRepository.GetWhereId(hotelBookingVM.HotelRoomId));

            return View(hotelBookingVM);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HotelBookingVM hotelBookingVM = new HotelBookingVM(_hotelBookingRepository.GetWhereId(id));

            if (hotelBookingVM == null)
            {
                return HttpNotFound();
            }
            return View(hotelBookingVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelBookingVM hotelBookingVM = new HotelBookingVM(_hotelBookingRepository.GetWhereId(id));
            _hotelBookingRepository.Delete(hotelBookingVM.ToModel());

            return RedirectToAction("Index");
        }

        public ActionResult StayOvernight()
        {
            _roomFactory.ChangeTamagotchiStats();
            return RedirectToAction("Index", "Tamagotchi");
        }


        private void ChangeTamagotchiHotelRoom(HotelBookingVM hotelBookingVM)
        {
            if (hotelBookingVM.TamagotchisIds != null)
            {
                List<TamagotchiVM> tamagotchisVM = hotelBookingVM.TamagotchisIds.Select(ti => new TamagotchiVM(_tamagotchiRepository.GetWhereId(ti))).ToList();

                foreach (var tamagotchiVM in tamagotchisVM)
                {
                    tamagotchiVM.HotelBooking = null;
                    tamagotchiVM.HotelRoomId = hotelBookingVM.HotelRoomId;
                    _tamagotchiRepository.Edit(tamagotchiVM.ToModel());
                }
            }
        }

        private void CheckIfYouCanBookRoom(HotelBookingVM hotelBookingVM)
        {
            var hotelroom = _hotelRoomRepository.GetWhereId(hotelBookingVM.HotelRoomId);
            if (hotelBookingVM.TamagotchisIds != null)
            {
                if (!(hotelBookingVM.TamagotchisIds.Count() <= hotelroom.RoomSize))
                {
                    ModelState.AddModelError("", $"Amount of tamagotchis is to big for this room(room size: {hotelroom.RoomSize})");
                }

                var tamagotchisVM = hotelBookingVM.TamagotchisIds.Select(ti => new TamagotchiVM(_tamagotchiRepository.GetWhereId(ti))).ToList();

                foreach (var tamagotchi in tamagotchisVM)
                {
                    if (tamagotchi.Money < hotelroom.HotelRoomType.RoomTypeCost)
                    {
                        ModelState.AddModelError("", $"{tamagotchi.Name} does not have enough money for this room ( room cost: {hotelroom.HotelRoomType.RoomTypeCost} , tamagotchi money: {tamagotchi.Money})");
                        break;
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Amount of tamagotchis can not be 0");
            }
        }
    }
}
