using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;

namespace Develop.Data
{
    public static class ManageUser
    {
        private static TestEngineEntities db = new TestEngineEntities();

        public static EFResponse Insert(User param)
        {
            EFResponse model = new EFResponse();

            try
            {
                param.IsDeleted = false;
                param.Createddate = DateTime.Now;
                db.Users.Add(param);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException != null ? e.InnerException.ToString() : e.Message;
                model.ErrorMessage = e.Message;
                model.Success = false;
            }

            return model;
        }

        public static EFResponse Update(User param)
        {
            EFResponse model = new EFResponse();

            try
            {
                db.Entry(param).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException != null ? e.InnerException.ToString() : e.Message;
                model.ErrorMessage = e.Message;
                model.Success = false;
            }

            return model;
        }

        public static EFResponse Delete(User param)
        {
            EFResponse model = new EFResponse();

            try
            {
                param.IsDeleted = true;
                db.Entry(param).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                model.ErrorEntity = e.InnerException != null ? e.InnerException.ToString() : e.Message;
                model.ErrorMessage = e.Message;
                model.Success = false;
            }

            return model;
        }

        public static List<User> GetAll()
        {
            return db.Users.Where(x => !x.IsDeleted).ToList();
        }

        public static User GetById(int id)
        {
            return db.Users.Where(x => !x.IsDeleted && x.ID == id).FirstOrDefault();
        }
    }
}
