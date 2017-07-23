using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradonix.Core.UI
{
    interface IOptionData:IBaseData
    {
        Dictionary<string,string> Options { get; set; }
    }
}
