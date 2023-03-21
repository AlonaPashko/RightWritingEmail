using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightWritingEmail.Interfases
{
    internal interface IPartDivider
    {
        public ILocalPart EstimateLocalPart();

        public IDomainNamePart EstimateDomainNamePart();
    }
}
