using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop.Model
{
    public class InvoiceModel
    {
        public string ID { get; set; }
        public int? UsersID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime? TransactionDate { get; set; }
        public long? TotalPrice { get; set; }
        public List<ListInvoiceModel> Items { get; set; }
    }

    public class ListInvoiceModel
    {
        public int CatalogueID { get; set; }
        public short Qty { get; set; }
    }
}
