using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradonix.Core.UI
{
    interface IUIPage
    {
        List<IBaseData> GetUIElements();
        void SetUIElements(List<IBaseData> data);
    }
}
