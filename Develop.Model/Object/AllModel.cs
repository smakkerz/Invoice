using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop.Model
{
    public class AllModel
    {
        public List<UsersModel> ListUsers { get; set; }
        public List<CatalogueModel> ListCatalogues { get; set; }
        public List<InvoiceModel> ListInvoices { get; set; }
    }
}
