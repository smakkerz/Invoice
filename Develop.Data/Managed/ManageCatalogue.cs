using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Develop.Data
{
    public partial class ManageCatalogue
    {
        private static TestEngineEntities db = new TestEngineEntities();

        public static EFResponse Insert(Catalogue param)
        {
            EFResponse model = new EFResponse();

            try
            {
                param.IsDeleted = false;
                param.Createddate = DateTime.Now;
                db.Catalogues.Add(param);
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

        public static EFResponse Update(Catalogue param)
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

        public static EFResponse Delete(Catalogue param)
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

        public static List<Catalogue> GetAll()
        {
            return db.Catalogues.Where(x => !x.IsDeleted).ToList();
        }

        public static Catalogue GetById(int id)
        {
            return db.Catalogues.Where(x => !x.IsDeleted && x.ID == id).FirstOrDefault();
        }
    }
}
