using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Develop.Data;
using System.Net.Http;
using System.Web.Http;
using Bussiness.Layer;
using System.Net;
using Develop.Model;

namespace Develop.API.Controllers
{
    public class UsersController : ApiController
    {
        [System.Web.Http.HttpPost]
        public ResultModel<EFResponse> Insert(User model)
        {
            var res = Logic.InsertUsers(model);
            return res;
        }
        
        [System.Web.Http.HttpPost]
        public ResultModel<EFResponse> Update(User model)
        {
            var res = Logic.UpdateUsers(model);
            return res;
        }
        
        [System.Web.Http.HttpGet]
        public ResultModel<EFResponse> DeleteId(int id)
        {
            var res = Logic.DeleteUsers(id);
            return res;
        }
        
        [System.Web.Http.HttpGet]
        public ResultModel<User> GetById(int id)
        {
            ResultModel<User> res = new ResultModel<User>();

            var ret = ManageUser.GetById(id);
            res.StatusCode = (int)HttpStatusCode.NotFound;
            if (ret != null)
            {
                res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
            }
            return res;
        }

        [System.Web.Http.HttpGet]
        public ResultModel<List<User>> GetByNamOrUser(string param)
        {
            ResultModel<List<User>> res = new ResultModel<List<User>>();

            var ret = ManageUser.GetAll()
                        .Where(x => x.Name.Contains(param) || x.Username.Contains(param)).ToList();
            res.StatusCode = (int)HttpStatusCode.NotFound;
            if (ret != null)
            {
                res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
            }
            return res;
        }

        [System.Web.Http.HttpGet]
        public ResultModel<List<User>> GetAll()
        {
            ResultModel<List<User>> res = new ResultModel<List<User>>();

            var ret = ManageUser.GetAll();
            res.StatusCode = (int)HttpStatusCode.NotFound;
            if (ret != null && ret.Count >= 1)
            {
                res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
            }
            return res;
        }
    }
}