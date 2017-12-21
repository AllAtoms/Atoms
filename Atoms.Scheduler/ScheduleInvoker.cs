using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace Atoms.Scheduler
{
    internal class ScheduleInvoker : IJob
    {
        internal static ScheduleManage ScheduleMgt = new ScheduleManage();

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var url = context.JobDetail.JobDataMap["url"].ToString();
                ScheduleMgt.InvokeLog("开始作业!", context.JobDetail.Key.Group, context.JobDetail.Key.Name, url);

                var hc = new HttpClient();
                var task = hc.GetStringAsync(url);
                ScheduleMgt.InvokeLog("正在调用... ", context.JobDetail.Key.Group, context.JobDetail.Key.Name, url);

                var watcher = new Stopwatch();
                watcher.Start();
                var result = task.Result;
                watcher.Stop();
                ScheduleMgt.InvokeLog("作业完成!", context.JobDetail.Key.Group, context.JobDetail.Key.Name, url, result, watcher.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                ScheduleMgt.InvokeLog("调用作业出错", context.JobDetail.Key.Group, context.JobDetail.Key.Name, context.JobDetail.JobDataMap["url"].ToString(), ex.Message);
            }
        }
    }

}
