using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Configuration;
using System.Web.Mvc;
using Common.Lib.RestAPI;
using Develop.Model;

namespace Develop.Web.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            var model = new AllModel();

            var ListUser = RESTHelper.Get<ResultModel<List<UsersModel>>>(ConfigurationManager.AppSettings["HostAPIURL"] + ConfigurationManager.AppSettings["GetAllUser"]);
            var ListCatalogue = RESTHelper.Get<ResultModel<List<CatalogueModel>>>(ConfigurationManager.AppSettings["HostAPIURL"] + ConfigurationManager.AppSettings["GetAllCatalague"]);
            var ListInvoice = RESTHelper.Get<ResultModel<List<InvoiceModel>>>(ConfigurationManager.AppSettings["HostAPIURL"] + ConfigurationManager.AppSettings["GetAllInvoice"]);
            ViewBag.NoInvoice = RESTHelper.Get<ResultModel<string>>(ConfigurationManager.AppSettings["HostAPIURL"] + ConfigurationManager.AppSettings["GenerateNoInvoice"]);
            if (ListCatalogue != null)
            {
                model.ListCatalogues = ListCatalogue.Value;
            }
            if(ListInvoice != null)
            {
                model.ListInvoices = ListInvoice.Value;
            }
            if(ListUser != null)
            {
                model.ListUsers = ListUser.Value;
            }
            if (TempData.ContainsKey("StatusMessage"))
                ViewBag.Message = TempData["StatusMessage"];

            return View(model);
        }

        [HttpPost]
        public virtual ActionResult SubmitCatalogue(CatalogueModel model)
        {
            var Submit = RESTHelper.Post<ResultModel<ResponseModel>>(ConfigurationManager.AppSettings["HostAPIURL"] + ConfigurationManager.AppSettings["AddCatalogue"], model);
            var response = "Success Insert Product";
            if (Submit.StatusCode != (int)HttpStatusCode.OK)
            {
                response = Submit.StatusMessage;
            }
            TempData["StatusMessage"] = response;
            return RedirectToAction(MVC.Home.Index());
        }

        [HttpPost]
        public virtual ActionResult SubmitUser(UsersModel model)
        {
            var Submit = RESTHelper.Post<ResultModel<ResponseModel>>(ConfigurationManager.AppSettings["HostAPIURL"] + ConfigurationManager.AppSettings["AddUser"], model);
            var response = "Success Insert Customer";
            if (Submit.StatusCode != (int)HttpStatusCode.OK)
            {
                response = Submit.StatusMessage;
            }
            TempData["StatusMessage"] = response;
            return RedirectToAction(MVC.Home.Index());
        }

        [HttpPost]
        public virtual ActionResult SubmitInvoice(InvoiceModel model)
        {
            var Submit = RESTHelper.Post<ResultModel<ResponseModel>>(ConfigurationManager.AppSettings["HostAPIURL"] + ConfigurationManager.AppSettings["AddInvoice"], model);
            var response = "Success Insert Invoice";
            if (Submit.StatusCode != (int)HttpStatusCode.OK)
            {
                response = Submit.StatusMessage;
            }
            TempData["StatusMessage"] = response;
            return RedirectToAction(MVC.Home.Index());
        }
    }
}