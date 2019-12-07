using System;
using System.Collections.Generic;
using EntityASP;
using EntityASP.Repository;
using NUnit.Framework;

namespace UnitTestASPNet
{
    [TestFixture]
    public class UnitTest1
        {
        [SetUp]
        protected void SetUp()
            {}

        [Test]
        public void ConnectionDatabase(AppDbContext appDbContext)
            {
            Assert.IsTrue(appDbContext.CheckConnection());
            }

        [Test]
        public List<T> GetList<T>(Repository<T> repository)
            {
            List<T> list = repository.FindAll();
            Assert.IsEmpty(list);
            return list;
            }
        }
    }
