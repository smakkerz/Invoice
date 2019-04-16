using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Develop.Data
{
    public partial class ManageInvoice
    {
        private static TestEngineEntities db = new TestEngineEntities();

        public static EFResponse Insert(Invoice param)
        {
            EFResponse model = new EFResponse();

            try
            {
                param.IsDeleted = false;
                param.Createddate = DateTime.Now;
                db.Invoices.Add(param);
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
        public static List<Invoice> GetAll()
        {
            return db.Invoices.Where(x => !x.IsDeleted).ToList();
        }

        public static Invoice GetById(string id)
        {
            return db.Invoices.Where(x => !x.IsDeleted && x.ID == id).FirstOrDefault();
        }
    }
}
