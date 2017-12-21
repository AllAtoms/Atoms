using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Atoms.Scheduler
{
    public class Scheduler
    {
        internal static string DbConnName;
        internal static ScheduleManage ScheduleMgt = new ScheduleManage();
        internal static IScheduler _scheduler;
        public static void Init(string dbConnStr, bool isRun = false)
        {
            DbConnName = dbConnStr;
            ScheduleMgt.CheckOrCreateDb();
            if (!isRun) return;

            _scheduler = StdSchedulerFactory.GetDefaultScheduler();
            _scheduler.Start();
            ScheduleMgt.Log("定时作业服务已启动");

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    JobBuild();
                    Thread.Sleep(1000 * 30);
                }
            });

        }

        internal static void JobBuild()
        {
            var jobs = ScheduleMgt.GetScheduleJobs();
            foreach (var job in jobs)
            {
                var jobKey = new JobKey(job.JobName, job.JobGroup);

                try
                {
                    if (job.State == 2)
                    {
                        //修改先删除
                        _scheduler.DeleteJob(jobKey);
                    }
                    else if (job.State == 3)
                    {
                        //删除并修改状态
                        var success = _scheduler.DeleteJob(jobKey);
                        if (success)
                        {
                            ScheduleMgt.SetState(job.Id, 4);
                            ScheduleMgt.Log("定时作业已经停止！！说明："+job.Descriptions, jobKey.Group, jobKey.Name);
                        }
                        else
                            ScheduleMgt.Log("定时作业停止失败！！说明：" + job.Descriptions, jobKey.Group, jobKey.Name);
                        continue;
                    }

                    //添加任务
                    if (_scheduler.CheckExists(jobKey)) continue;
                    var builderJob = JobBuilder.Create<ScheduleInvoker>();
                    builderJob.WithIdentity(job.JobName, job.JobGroup);
                    builderJob.UsingJobData("url", job.JobUrl);
                    var iBuilderJob = builderJob.Build();

                    var builderTrigger = TriggerBuilder.Create();
                    builderTrigger.WithIdentity(job.JobName + "Trigger", job.JobGroup);
                    builderTrigger.WithCronSchedule(job.Cron);

                    if (job.StartTime.HasValue) builderTrigger.StartAt(job.StartTime.Value);
                    if (job.EndTime.HasValue) builderTrigger.EndAt(job.EndTime.Value);

                    var iBuilderTrigger = builderTrigger.Build();
                    _scheduler.ScheduleJob(iBuilderJob, iBuilderTrigger);
                    ScheduleMgt.Log("定时作业配置更新完成！！说明：" + job.Descriptions, jobKey.Group, jobKey.Name);
                    //添加后状态改为正常
                    ScheduleMgt.SetState(job.Id,1);
                }
                catch (Exception ex)
                {
                    ScheduleMgt.Log("定时作业服务添加出错:"+ ex.Message, jobKey.Group, jobKey.Name);
                }
            }
        }

    }
}
