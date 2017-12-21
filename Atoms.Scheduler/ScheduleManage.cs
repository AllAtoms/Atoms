using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm.Son.Core;

namespace Atoms.Scheduler
{
    internal class ScheduleManage
    {
        public bool CheckOrCreateDb()
        {
            using (var db = new Db())
            {
                var resA = db.CreateTable<AtomSchedule>();
                var resB = db.CreateTable<AtomScheduleLogs>();
                return resA&& resB;
            }
        }

        internal long Log(string  txt,string group = "",string name="")
        {
            using (var db = new Db())
            {
                return db.Insert(new AtomScheduleLogs
                {
                    LogType ="信息",
                    Duration =0d,
                    InvokeResult ="",
                    InvokeUrl ="",
                    JobGroup= group,
                    JobName= name,
                    Desc =txt,
                    AddTime = DateTime.Now
                });
            }
        }

        internal long InvokeLog(string txt, string group = "", string name = "",string url= "",string result="",double duration=0)
        {
            using (var db = new Db())
            {
                return db.Insert(new AtomScheduleLogs
                {
                    LogType = "调用",
                    Duration = duration,
                    InvokeResult = result,
                    InvokeUrl = url,
                    JobGroup = group,
                    JobName = name,
                    Desc = txt,
                    AddTime = DateTime.Now
                });
            }
        }

        internal List<AtomSchedule> GetScheduleJobs()
        {
            using (var db = new Db())
            {
                return db.FindMany<AtomSchedule>(t => t.Id > 0);
            }
        }

        internal  void SetState(int id,int state)
        {
            using (var db = new Db())
            {
                var job = db.Find<AtomSchedule>(id);
                job.State = state;
                db.Update(job);
            }
        }
    }
}
