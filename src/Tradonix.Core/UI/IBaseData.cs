using System;

namespace Tradonix.Core.UI
{
    interface IBaseData
    {
        string Label { get; set; }
        string Data { get; set; }
        UITypeEnum UIType { get; }
        TypeCode TypeCode { get; }
    }
}
