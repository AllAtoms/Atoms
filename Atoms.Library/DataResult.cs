using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atoms.Library
{
    public class DataResult<T>
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 扩展数据
        /// </summary>
        public object ExtData { get; set; }

        public DataResult(int status = 200, T data = default(T), string msg = null, object extDate = null)
        {
            Status = status;
            Data = data;
            Msg = msg;
            ExtData = extDate;
        }

    }
}
