using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAT.Models;
using VAT.ServiceReferenceCheckVat;

namespace VAT.Controllers
{
    public class HomeController : Controller
    {
        private VatDbContext db = new VatDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Vat()
        {
            checkVatPortTypeClient vat = new checkVatPortTypeClient();
            var model = new List<VatViewModel>();
            var searchedVats = this.db.Vats.OrderByDescending(x => x.Id)
                .Select(v => v.VatNumber)
                .ToList();

            foreach (var searchedVat in searchedVats)
            {
                bool valid;
                string name;
                string address;
                string countryCode = searchedVat.Substring(0, 2);
                string vatNumber = searchedVat.Substring(2);

                var a = vat.checkVat(ref countryCode, ref vatNumber, out valid, out name, out address);
                var checkVat = new VatViewModel
                {
                    IsValid = valid,
                    Name = name,
                    Address = address
                };
                model.Add(checkVat);
            }
            return View("Vat",model:model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VatNumber")] Vat vat)
        {
            if (ModelState.IsValid)
            {
                this.db.Vats.Add(vat);
                db.SaveChanges();
                return RedirectToAction("Vat");
            }

            return View(vat);
        }
    }
}