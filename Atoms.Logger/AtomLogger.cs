using Orm.Son.Mapper;
using System;

namespace Atoms.Logger
{
    internal class AtomLogger
    {
        [Description("日志ID")]
        public int Id { get; set; }
        [Description("日志类型")]
        public string LogType { get; set; }
        [Description("日志级别")]
        public int LogLevel { get; set; }
        [Description("操作日志")]
        public int LogUser { get; set; }
        [Description("调用地址")]
        public string LogUrl { get; set; }
        [Description("日志内容")]
        public string LogTxt { get; set; }
        [Description("执行时间(ms)")]
        public double Duration { get; set; }
        [Description("添加时间")]
        public DateTime AddTime { get; set; }
    }
}
