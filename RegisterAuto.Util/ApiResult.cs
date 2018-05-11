using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterAuto.Util
{
    public class ApiResult<T>
    {
        public T Data { get; set; }

        public string Msg { get; set; }

        public int Code { get; set; }

        public DateTime Time { get; set; }
    }
}
