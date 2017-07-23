using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradonix.Core.UI
{
    public class SimpleData : IBaseData
    {
        public SimpleData(TypeCode typeCode)
        {
            this.TypeCode = typeCode;
            this.UIType = UITypeEnum.Text;
        }

        public SimpleData()
        {
            this.TypeCode = TypeCode.String;
            this.UIType = UITypeEnum.Text;
        }

        public string Label { get; set; }
        public string Data { get; set; }
        public string RegExToValidate { get; set; }
        public string FormattingData { get; set; }
        public UITypeEnum UIType { get; }
        public TypeCode TypeCode { get; }
    }
}
