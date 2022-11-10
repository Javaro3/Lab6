using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Tests
{
    [TestClass()]
    public class TheatersTests
    {
        [TestMethod()]
        public void CheckDataTest1()
        {
            Theaters theaters = new Theaters();
            Assert.IsTrue(theaters.CheckData("12.12.12"));
        }

        [TestMethod()]
        public void CheckKolTest1()
        {
            Theaters theaters = new Theaters();
            Assert.IsTrue(theaters.CheckKol("123"));
        }

        [TestMethod()]
        public void CheckGenreTest1()
        {
            Theaters theaters = new Theaters();
            Assert.IsTrue(theaters.CheckGenre("Drama"));
        }

        [TestMethod()]
        public void CheckNameTest1()
        {
            Theaters theaters = new Theaters();
            Assert.IsTrue(theaters.CheckName("Gore ot Yma"));
        }

        [TestMethod()]
        public void CheckDateBetweenTest1()
        {
            Theaters theaters = new Theaters();
            Assert.IsTrue(theaters.CheckDateBetween("11.12.12", "13.12.12", "12.12.12"));
        }

        [TestMethod()]
        public void CheckDataTest2()
        {
            Theaters theaters = new Theaters();
            Assert.IsFalse(theaters.CheckData("30.02.12"));
        }

        [TestMethod()]
        public void CheckKolTest2()
        {
            Theaters theaters = new Theaters();
            Assert.IsFalse(theaters.CheckKol("asd"));
        }

        [TestMethod()]
        public void CheckGenreTest2()
        {
            Theaters theaters = new Theaters();
            Assert.IsFalse(theaters.CheckGenre("123"));
        }

        [TestMethod()]
        public void CheckNameTest2()
        {
            Theaters theaters = new Theaters();
            Assert.IsFalse(theaters.CheckName("   "));
        }

        [TestMethod()]
        public void CheckDateBetweenTest2()
        {
            Theaters theaters = new Theaters();
            Assert.IsFalse(theaters.CheckDateBetween("11.12.12", "13.12.12", "14.12.12"));
        }
    }
}