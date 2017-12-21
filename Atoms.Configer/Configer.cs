using System;
using System.Collections.Generic;

namespace Atoms.Configer
{
    public class Configer
    {
        internal static string DbConnName;
        internal static ConfigManage Confm= new ConfigManage();
        public static void Init(string dbConnStr)
        {
            DbConnName = dbConnStr;
            Confm.CheckOrCreateDb();
        }

        public static bool Set(string key,string value, string parentKey = "", string name ="",string desc ="",  int version =1)
        {
            var cc = new AtomConfiger()
            {
                Key = key,
                Value = value,
                Version = version,
                Name = name,
                Description = desc,
                AddTime = DateTime.Now,
                EditTime = DateTime.Now,
                Enable = true
            };
            return Confm.AddConfig(cc,parentKey)>0;
        }

        public static AtomConfiger Get(string key)
        {
           return Confm.GetConfig(key);
        }

        public static List<AtomConfiger> Gets(string parentkey)
        {
            return Confm.GetConfigs(parentkey);
        }

    }
}
