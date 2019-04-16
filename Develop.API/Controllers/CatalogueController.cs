using System;
using System.Collections.Generic;
using System.Linq;
using Develop.Data;
using System.Net.Http;
using System.Web.Http;
using Bussiness.Layer;
using System.Net;
using Develop.Model;

namespace Develop.API.Controllers
{
    public class CatalogueController : ApiController
    {
        [System.Web.Http.HttpPost]
        public ResultModel<EFResponse> Insert(Catalogue model)
        {
            return Logic.InsertCatalogue(model);
        }

        [System.Web.Http.HttpPost]
        public ResultModel<EFResponse> Update(Catalogue model)
        {
            return Logic.UpdateCatalogue(model);
        }

        [System.Web.Http.HttpGet]
        public ResultModel<Catalogue> GetById(int id)
        {
            ResultModel<Catalogue> res = new ResultModel<Catalogue>();

            var ret = ManageCatalogue.GetById(id);
            res.StatusCode = (int)HttpStatusCode.NotFound;
            if (ret != null)
            {
                res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
            }
            return res;
        }

        [System.Web.Http.HttpGet]
        public ResultModel<List<Catalogue>> GetByNameOrCode(string param)
        {
            ResultModel<List<Catalogue>> res = new ResultModel<List<Catalogue>>();

            var ret = ManageCatalogue.GetAll()
                        .Where(x => x.Name.Contains(param) || x.Code.Contains(param)).ToList();
            res.StatusCode = (int)HttpStatusCode.NotFound;
            if (ret != null)
            {
                res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
            }
            return res;
        }

        [System.Web.Http.HttpGet]
        public ResultModel<List<Catalogue>> GetAll()
        {
            ResultModel<List<Catalogue>> res = new ResultModel<List<Catalogue>>();

            var ret = ManageCatalogue.GetAll().Where(x => x.Qty > 1).ToList();
            res.StatusCode = (int)HttpStatusCode.NotFound;
            if (ret != null && ret.Count >= 1)
            {
                res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
            }
            return res;
        }
    }
}