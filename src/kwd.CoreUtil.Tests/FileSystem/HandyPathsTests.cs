using System;
using System.IO;
using kwd.CoreUtil.FileSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kwd.CoreUtil.Tests.FileSystem
{
    [TestClass]
    public class HandyPathsTests
    {
        [TestMethod]
        public void Home_PreferHomeEnvironmentVariable()
        {
            var tmp = new DirectoryInfo("c:/temp/test");
            Environment.SetEnvironmentVariable("USERPROFILE", tmp.GetFile("other").FullName);
            Environment.SetEnvironmentVariable("HOME", tmp.FullName);

            var home = HandyPaths.Home();
            Assert.AreEqual(tmp.FullName, home.FullName, "Use $HOME");
        }
    }
}