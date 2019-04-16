using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop.Model
{
    public class ResultModel<T>
    {
        public ResultModel()
        {

        }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public T Value { get; set; }
    }
}
