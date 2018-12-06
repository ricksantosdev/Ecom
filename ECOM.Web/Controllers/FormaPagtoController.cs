using AutoMapper;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ECOM.Web.Controllers
{
    public class FormaPagtoController : Controller
    {
        private readonly FormaPagtoApp _formaPagtoApp;

        public FormaPagtoController(FormaPagtoApp formaPagtoApp)
        {
            _formaPagtoApp = formaPagtoApp;
        }

        public ActionResult Index()
        {
            List<FormaPagtoViewModels> formaPagtosVW = Mapper.Map<IEnumerable<FormaPagto>, IEnumerable<FormaPagtoViewModels>>(_formaPagtoApp.GetAll()).ToList();

            if (Request.IsAjaxRequest())
                return PartialView(formaPagtosVW);

            return View(formaPagtosVW);
        }

        public ActionResult CreateEdit(int? id)
        {
            FormaPagtoViewModels fPagtoVW;
            if (id != null)
                fPagtoVW = Mapper.Map<FormaPagto, FormaPagtoViewModels>(_formaPagtoApp.GetEntityById(id.Value));
            else
                fPagtoVW = new FormaPagtoViewModels();

            if (Request.IsAjaxRequest())
                return PartialView(fPagtoVW);
            return View(fPagtoVW);
        }
        
        [HttpPost]
        public ActionResult CreateEdit(FormaPagtoViewModels fPagtoVW)
        {
            if(ModelState.IsValid)
            {
                FormaPagto formaPagto = Mapper.Map<FormaPagtoViewModels, FormaPagto>(fPagtoVW);
                if (fPagtoVW.Id == 0)
                    _formaPagtoApp.AddEntity(formaPagto);
                else
                    _formaPagtoApp.UpdateEntity(formaPagto);
                return RedirectToAction("Index");
            }
            return View(fPagtoVW);
        }

        public ActionResult Delete(int id)
        {
            _formaPagtoApp.DeleteEntity(_formaPagtoApp.GetEntityById(id));

            return Json(new { status = "deletado com sucesso", JsonRequestBehavior.AllowGet });
        }
    }
}