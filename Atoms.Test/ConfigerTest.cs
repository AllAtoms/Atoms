using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atoms.Test
{
    [TestClass]
    public class ConfigerTest
    {
        [TestInitialize]
        public void Init()
        {
            Configer.Configer.Init("conn");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Configer.Configer.Set("keytest", "valuetest");
            Configer.Configer.Set("group1", "group1");
            Configer.Configer.Set("key1", "value1","group1");
            Configer.Configer.Set("key2", "value2","group1");

            var val = Configer.Configer.Get("keytest");
            var vals = Configer.Configer.Gets("group1");
        }
    }
}
