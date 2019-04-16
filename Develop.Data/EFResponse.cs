using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop.Data
{
    public class EFResponse
    {
        public EFResponse()  // static ctor
        {
            Success = true;
        }

        public bool Success { get; set; }
        public string ErrorEntity { get; set; }
        public string ErrorMessage { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
