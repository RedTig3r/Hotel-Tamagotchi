using System.Net;
using System.Web.Mvc;
using HotelTamagotchi.Models.ViewModel;
using HotelTamagotchi.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace HotelTamagotchi.Controllers
{
    //[Authorize]
    public class TamagotchiController : Controller
    {
        private readonly TamagotchiRepository _tamagotchiRepository;
        private readonly PlayerUserRepository _playerUserRepository;

        public TamagotchiController(
            TamagotchiRepository tamagotchiRepository,
            PlayerUserRepository playerUserRepository
            )
        {
            this._playerUserRepository = playerUserRepository;
            this._tamagotchiRepository = tamagotchiRepository;
        }

        // GET: Tamagotchi
        public ActionResult Index()
        {

            List<TamagotchiVM> tamagotchisVM = _tamagotchiRepository.GetAll().Select(t => new TamagotchiVM(t)).ToList();

            return View(tamagotchisVM);
        }

        // GET: Tamagotchi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tamagotchiVM = new TamagotchiVM(_tamagotchiRepository.GetWhereId(id));
            if (tamagotchiVM == null)
            {
                return HttpNotFound();
            }

            return View(tamagotchiVM);
        }

        // GET: Tamagotchi/Create
        public ActionResult Create()
        {
            ViewBag.PlayerUserId = new SelectList(_playerUserRepository.GetAll(), "PlayerUserId", "PlayerUserName");
            var tamagotchiVM = new TamagotchiVM();
            tamagotchiVM.IsALive = true;
            return View(tamagotchiVM);
        }

        // POST: Tamagotchi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TamagotchiVM tamagotchiVM)
        {

            ViewBag.PlayerUserId = new SelectList(_playerUserRepository.GetAll(), "PlayerUserId", "PlayerUserName", tamagotchiVM.PlayerUserId);

            tamagotchiVM.IsALive = true;
            if (ModelState.IsValid)
            {

                _tamagotchiRepository.Add(tamagotchiVM.ToModel());
                return RedirectToAction("Index");
            }

            return View(tamagotchiVM);
        }

        // GET: Tamagotchi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tamagotchiVM = new TamagotchiVM(_tamagotchiRepository.GetWhereId(id));

            if (tamagotchiVM == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerUserId = new SelectList(_playerUserRepository.GetAll(), "PlayerUserId", "PlayerUserName", tamagotchiVM.PlayerUserId);

            return View(tamagotchiVM);
        }

        // POST: Tamagotchi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TamagotchiVM tamagotchiVM)
        {
            if (ModelState.IsValid)
            {
                _tamagotchiRepository.Edit(tamagotchiVM.ToModel());
                return RedirectToAction("Index");
            }
            ViewBag.PlayerUserId = new SelectList(_playerUserRepository.GetAll(), "PlayerUserId", "PlayerUserName", tamagotchiVM.PlayerUserId);

            return View(tamagotchiVM);
        }

        // GET: Tamagotchi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tamagotchiVM = new TamagotchiVM(_tamagotchiRepository.GetWhereId(id));

            if (tamagotchiVM == null)
            {
                return HttpNotFound();
            }

            return View(tamagotchiVM);
        }

        // POST: Tamagotchi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tamagotchi = _tamagotchiRepository.GetWhereId(id);
            _tamagotchiRepository.Delete(tamagotchi);

            return RedirectToAction("Index");
        }

    

    }
}