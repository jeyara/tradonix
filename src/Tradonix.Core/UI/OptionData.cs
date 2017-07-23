using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tradonix.Core.UI
{
    public class OptionData : IOptionData
    {
        public OptionData(TypeCode typeCode, Dictionary<string, string> options)
        {
            this.TypeCode = typeCode;
            this.UIType = UITypeEnum.Text;
            this.Options = options;
        }

        public OptionData()
        {
            this.TypeCode = TypeCode.String;
            this.UIType = UITypeEnum.Text;
            this.Options = new Dictionary<string, string>();
        }

        public string Label { get; set; }
        public string Data { get; set; }
        public string ReExToValidate { get; set; }
        public string Format { get; set; }
        public UITypeEnum UIType { get; }
        public TypeCode TypeCode { get; }
        public Dictionary<string, string> Options { get; set; }
    }
}
