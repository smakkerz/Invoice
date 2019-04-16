using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop.Model
{
    public class UsersModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Createddate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
