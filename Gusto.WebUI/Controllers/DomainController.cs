using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gusto.Business.Abstract;
using Gusto.Entities.ComplexType;

namespace Gusto.WebUI.Controllers
{
    public class DomainController : Controller
    {
        private IDomainService _domainService;

        public DomainController(IDomainService domainService)
        {
            _domainService = domainService;
        }

        public ActionResult Index(SearchDomainModel model)
        {
            model = model ?? new SearchDomainModel();
            var response = _domainService.DomainList(model);
            if (response.Success)
                return View(response.Data);
            return Redirect("~/Views/Shared/Error.cshtml");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddDomainModel model)
        {
            var response = _domainService.AddDomain(model);
            if (response.Success)
                return RedirectToAction("Index", "Domain", new { notificationSuccess = response.Message });
            return RedirectToAction("Index", "Domain", new { notificationError = response.Message });

        }
        public ActionResult Edit(int id)
        {
            var response = _domainService.DomainById(id);
            if (response.Success)
                return View(response.Data);
            return RedirectToAction("Index", "Domain", new { notificationError = response.Message });
        }
        [HttpGet]
        public JsonResult EditAjax(UpdateDomainModel model)
        {
            
            var response = _domainService.UpdateAjaxDataDomain(model);
            if (response.Success)
                return Json(1,JsonRequestBehavior.AllowGet);
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            var response = _domainService.DeleteDomain(id);
            if (response.Success)
                return RedirectToAction("Index", "Domain", new { notificationSuccess = response.Message });
            return RedirectToAction("Index", "Domain", new { notificationError = response.Message });
        }

        
    }
}