using System;
using System.Linq;
using System.Net;
using Develop.Data;
using Common.Lib.Encrypt;
using Develop.Model;

namespace Bussiness.Layer
{
    public class Logic
    {
        #region Part Helper and Validation
        private static ResultModel<EFResponse> res = new ResultModel<EFResponse>();
        private static ResultModel<string> end = new ResultModel<string>();

        private static ResultModel<string> _validationUsers(User param)
        {
            end.StatusCode = (int)HttpStatusCode.NotAcceptable;
            if (param == null)
            {
                end.StatusMessage = "Parameter is empty";
                return end;
            }
            if (string.IsNullOrEmpty(param.Username))
            {
                end.StatusMessage = "Username is required";
                return end;
            }
            if (param.Username.Split(' ').Length > 1)
            {
                end.StatusMessage = "Username is not valid";
                return end;
            }
            if (string.IsNullOrEmpty(param.Password))
            {
                end.StatusMessage = "Password is required";
                return end;
            }
            if (string.IsNullOrEmpty(param.Name))
            {
                end.StatusMessage = "Name is required";
                return end;
            }
            var user = ManageUser.GetAll().FirstOrDefault(x => x.Username == param.Username);
            if(user != null)
            {
                end.StatusMessage = "Username is used";
                return end;
            }
            end.StatusCode = (int)HttpStatusCode.OK;
            return end;
        }

        private static ResultModel<string> _validationInvoice(InvoiceModel param)
        {
            end.StatusCode = (int)HttpStatusCode.NotAcceptable;
            if(param == null)
            {
                end.StatusMessage = "Parameter is empty";
                return end;
            }
            if (string.IsNullOrEmpty(param.ID))
            {
                end.StatusMessage = "No Invoice is required";
                return end;
            }
            if (!param.TransactionDate.HasValue)
            {
                end.StatusMessage = "Transaction Date is required";
                return end;
            }
            if (!param.UsersID.HasValue)
            {
                end.StatusMessage = "Customer is required";
                return end;
            }
            if(param.Items.Count < 1)
            {
                end.StatusMessage = "List Product is required";
                return end;
            }
            var user = ManageUser.GetById(param.UsersID.Value);
            if(user == null)
            {
                end.StatusMessage = "Customer is not found";
                return end;
            }
            var No = ManageInvoice.GetById(param.ID);
            if(No != null)
            {
                param.ID = GenerateInvoice().Value;
            }
            foreach(ListInvoiceModel item in param.Items)
            {
                var Product = ManageCatalogue.GetById(item.CatalogueID);
                if(Product == null)
                {
                    end.StatusMessage = "Product is not found";
                    return end;
                }
                if(Product.Qty < item.Qty)
                {
                    end.StatusMessage = "Quantity Product smaller than Request";
                    return end;
                }
            }
            end.StatusCode = (int)HttpStatusCode.OK;
            return end;
        }
        private static ResultModel<string> _validationCatalogue(Catalogue param)
        {
            end.StatusCode = (int)HttpStatusCode.NotAcceptable;
            if (param == null)
            {
                end.StatusMessage = "Parameter is empty";
                return end;
            }
            if (string.IsNullOrEmpty(param.Code))
            {
                end.StatusMessage = "No Invoice is required";
                return end;
            }
            if (!param.Qty.HasValue)
            {
                end.StatusMessage = "Transaction Date is required";
                return end;
            }
            if (!param.Price.HasValue)
            {
                end.StatusMessage = "Customer is required";
                return end;
            }
            if (param.Price < 1 || param.Qty < 1)
            {
                end.StatusMessage = "Oops...!! Price or Quantity add more";
                return end;
            }
            var catalog = ManageCatalogue.GetAll().FirstOrDefault(x => x.Code == param.Code);
            if (catalog != null)
            {
                end.StatusMessage = "Code is used";
                return end;
            }
            end.StatusCode = (int)HttpStatusCode.OK;
            return end;
        }
        #endregion

        public static ResultModel<EFResponse> InsertUsers(User param)
        {
            var validate = _validationUsers(param); 
            if(validate.StatusCode != (int)HttpStatusCode.OK)
            {
                res.StatusCode = validate.StatusCode;
                res.StatusMessage = validate.StatusMessage;
                return res;
            }
            param.Password = Encryption.Encode(param.Password);
            var ret = ManageUser.Insert(param);
            res.StatusCode = (int)HttpStatusCode.ExpectationFailed;
            if (ret.Success)
            {
                res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
            }
            return res;
        }
        public static ResultModel<EFResponse> UpdateUsers(User param)
        {
            res.StatusCode = (int)HttpStatusCode.NotFound;
            var User = ManageUser.GetById(param.ID);
            if(User != null)
            {
                res.StatusCode = (int)HttpStatusCode.Found;
                var ret = ManageUser.Update(param);
                if (ret.Success)
                {
                    res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
                }
            }
            return res;
        }
        public static ResultModel<EFResponse> DeleteUsers(int ID)
        {
            res.StatusCode = (int)HttpStatusCode.NotFound;
            var User = ManageUser.GetById(ID);
            if (User != null)
            {
                res.StatusCode = (int)HttpStatusCode.Found;
                var ret = ManageUser.Delete(User);
                if (ret.Success)
                {
                    res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
                }
            }
            return res;
        }
        public static ResultModel<EFResponse> InsertCatalogue(Catalogue param)
        {
            var validate = _validationCatalogue(param);
            if (validate.StatusCode != (int)HttpStatusCode.OK)
            {
                res.StatusCode = validate.StatusCode;
                res.StatusMessage = validate.StatusMessage;
                return res;
            }
            var ret = ManageCatalogue.Insert(param);
            res.StatusCode = (int)HttpStatusCode.ExpectationFailed;
            if (ret.Success)
            {
                res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
            }
            return res;
        }
        public static ResultModel<EFResponse> UpdateCatalogue(Catalogue param)
        {
            res.StatusCode = (int)HttpStatusCode.NotFound;
            var User = ManageCatalogue.GetById(param.ID);
            if (User != null)
            {
                res.StatusCode = (int)HttpStatusCode.Found;
                var ret = ManageCatalogue.Update(param);
                if (ret.Success)
                {
                    res.StatusCode = (int)HttpStatusCode.OK; res.Value = ret;
                }
            }
            return res;
        }
        public static ResultModel<EFResponse> InsertInvoice(InvoiceModel param)
        {
            var validate = _validationInvoice(param);
            if (validate.StatusCode != (int)HttpStatusCode.OK)
            {
                res.StatusCode = validate.StatusCode;
                res.StatusMessage = validate.StatusMessage;
                return res;
            }

            res.StatusCode = (int)HttpStatusCode.OK;
            long Total = 0;

            Invoice Receipt = new Invoice();
            Receipt.ID = param.ID;
            Receipt.TransactionDate = param.TransactionDate;
            Receipt.UsersID = param.UsersID;

            foreach(ListInvoiceModel item in param.Items)
            {
                var product = ManageCatalogue.GetById(item.CatalogueID);
                #region To List Invoice
                Total = Total + (product.Price.Value * item.Qty);
                ListInvoice collect = new ListInvoice();
                collect.InovicesID = Receipt.ID;
                collect.CatalogueID = item.CatalogueID;
                collect.Qty = item.Qty;
                collect.Price = product.Price;
                collect.SumPrice = (product.Price * item.Qty);
                ManageListInvoice.Insert(collect);
                #endregion

                product.Qty = Convert.ToInt16(product.Qty - item.Qty);
                UpdateCatalogue(product);
            }

            Receipt.TotalPrice = Total;
            var ret = ManageInvoice.Insert(Receipt);

            return res;
        }
        public static ResultModel<string> GenerateInvoice()
        {        
            string Y = DateTime.Now.Year.ToString().Substring(2);
            string NoInvoice = Y + "0001";

            var data = ManageInvoice.GetAll().OrderByDescending(x => x.Createddate).FirstOrDefault();
            if (data != null)
            {
                if(data.Createddate.Value.Year == DateTime.Now.Year)
                {
                    int d = Convert.ToInt32(data.ID) + 1;
                    NoInvoice = d.ToString();
                }
                //// Mengambil 4 karakter kanan terakhir dari field nomor lalu menambahkan dengan 1
                //hitung = Convert.ToInt64(rd["nomor"]) + 1;
                //string joinstr = "0000" + hitung;
                //// Mengambil 4 karakter kanan terakhir dari string joinstr
                //urut = joinstr.Substring(joinstr.Length - 4, 4);
            }

            end.StatusCode = (int)HttpStatusCode.OK; end.Value = NoInvoice;

            return end;
        }
        
    }
}
