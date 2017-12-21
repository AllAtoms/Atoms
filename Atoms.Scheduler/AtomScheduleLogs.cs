using Orm.Son.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atoms.Scheduler
{
    internal class AtomScheduleLogs
    {
        public int Id { get; set; }
        public string LogType { get; set; }
        public string JobGroup { get; set; }
        public string JobName { get; set; }
        public string InvokeUrl { get; set; }
        public string InvokeResult { get; set; }
        public double Duration { get; set; }
        public string Desc { get; set; }
        public DateTime AddTime { get; set; }
    }
}
