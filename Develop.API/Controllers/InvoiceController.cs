using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bussiness.Layer;
using Develop.Data;
using Develop.Model;

namespace Develop.API.Controllers
{
    public class InvoiceController : ApiController
    {
        [System.Web.Http.HttpPost]
        public ResultModel<EFResponse> Insert(InvoiceModel model)
        {
            return Logic.InsertInvoice(model);
        }

        [System.Web.Http.HttpGet]
        public ResultModel<List<InvoiceModel>> GetAll()
        {
            ResultModel<List<InvoiceModel>> res = new ResultModel<List<InvoiceModel>>();

            var ret = ManageInvoice.GetAll();
            var datas = (from a in ret
                                  join b in ManageUser.GetAll() on a.UsersID equals b.ID
                                  select new InvoiceModel
                                  {
                                      ID = a.ID,
                                      UsersID = a.UsersID,
                                      UserName = b.Username,
                                      Name = b.Name,
                                      TransactionDate = a.TransactionDate,
                                      TotalPrice = a.TotalPrice
                                  }).ToList();
            res.StatusCode = (int)HttpStatusCode.NotFound;
            if (datas != null && datas.Count >= 1)
            {
                res.StatusCode = (int)HttpStatusCode.OK; res.Value = datas;
            }
            return res;
        }

        [System.Web.Http.HttpGet]
        public ResultModel<string> GenerateNoInvoice()
        {
            return Logic.GenerateInvoice();
        }
    }
}
