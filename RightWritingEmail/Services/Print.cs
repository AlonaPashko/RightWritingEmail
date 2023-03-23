using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightWritingEmail.Services
{
    internal static class Print
    {
        public static string PrintStringList(List<string> list) 
        {
            string line = "";
            foreach (var item in list)
            {
                line += item + "\n";
            }
            return line;
        }
    }
}
