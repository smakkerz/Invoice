using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scrypt;

namespace Common.Lib.Encrypt
{
    public class Encryption
    {
        private static ScryptEncoder encoder = new ScryptEncoder();

        public static string Encode(string param)
        {
            return encoder.Encode(param);
        }

        public static bool Compare(string param, string Hashparam)
        {
            return encoder.Compare(param, Hashparam);
        }
    }
}
