using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeCoinApi.Controllers
{
    public class CoinController : Controller
    {
        // GET: CoinController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CoinController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CoinController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoinController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoinController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CoinController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoinController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CoinController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
