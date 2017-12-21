using System;
using System.Collections.Generic;
using Orm.Son.Core;

namespace Atoms.Configer
{
    internal class ConfigManage
    {
        public bool CheckOrCreateDb()
        {
            using (var db = new Db())
            {
                return db.CreateTable<AtomConfiger>();
            }
        }

        public long AddConfig(AtomConfiger cfg, string parentKey)
        {
            using (var db = new Db())
            {
                if (!string.IsNullOrEmpty(parentKey))
                {
                    var conf = GetConfig(parentKey);
                    if (conf == null) throw new Exception("没有上级配置");
                    cfg.ParentId = conf.Id;
                }

                var exist = db.Top<AtomConfiger>(t => t.Key == cfg.Key);
                if (exist == null)
                    return db.Insert(cfg);

                exist.Name = cfg.Name;
                exist.ParentId = cfg.ParentId;
                exist.Value = cfg.Value;
                exist.Version = cfg.Version;
                exist.Description = cfg.Description;
                exist.EditTime = DateTime.Now;
                return db.Update(exist);
            }
        }

        public AtomConfiger GetConfig(string key)
        {
            using (var db = new Db())
            {
                return db.Top<AtomConfiger>(t => t.Key == key);
            }
        }

        public List<AtomConfiger> GetConfigs(string key)
        {
            using (var db = new Db())
            {
                var cc = db.Top<AtomConfiger>(t => t.Key == key);
                return db.FindMany<AtomConfiger>(t => t.ParentId == cc.Id);
            }
        }

    }
}
