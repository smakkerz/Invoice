using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop.Model
{
    public class CatalogueModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short Qty { get; set; }
        public long Price { get; set; }
        public DateTime Createddate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
