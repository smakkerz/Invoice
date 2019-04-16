using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop.Data
{
    public partial class ManageListInvoice
    {
        private static TestEngineEntities db = new TestEngineEntities();

        public static EFResponse Insert(ListInvoice param)
        {
            EFResponse model = new EFResponse();

            try
            {
                param.IsDeleted = false;
                param.Createddate = DateTime.Now;
                db.ListInvoices.Add(param);
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
        public static List<ListInvoice> GetAll()
        {
            return db.ListInvoices.Where(x => !x.IsDeleted).ToList();
        }

        public static ListInvoice GetById(int id)
        {
            return db.ListInvoices.Where(x => !x.IsDeleted && x.ID == id).FirstOrDefault();
        }
    }
}
