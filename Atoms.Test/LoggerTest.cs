using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atoms.Test
{
    [TestClass]
    public class LoggerTest
    {
        [TestInitialize]
        public void Init()
        {
            Logger.Logger.Init("conn");
        }

        [TestMethod]
        public void TestMethod1()
        {
            for (var i = 0; i < 100; i++)
            {
                Logger.Logger.Info("这是一个标准日志" + i);
                Logger.Logger.Warn("这是一个警告日志" + i);
                Logger.Logger.Error("这是一个错误日志" + i);
                Logger.Logger.Fatal("这是一个严重错误日志" + i);
                Logger.Logger.Exception(new Exception("这是一个异常" + i));
            }
        }
    }
}
