using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightWritingEmail.Interfases
{
    internal interface IStringChecker
    {
        public bool IsAtSign();

        public bool IsNormalLength();
    }
}
