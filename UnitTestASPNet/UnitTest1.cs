using System;
using System.Collections.Generic;
using EntityASP;
using EntityASP.Entity;
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

        [Test]
        public List<T> GetListFiltered<T>(Repository<T> repository, Dictionary<String, String> criteria, Dictionary<String, String> orderBy = null, ulong? limit = null, ulong? offset = null)
            {
            List<T> list = repository.FindBy(criteria, orderBy, limit, offset);
            Assert.IsEmpty(list);
            return list;
            }

        [Test]
        public void ToAccessAdmin(Person person)
            {
            Assert.IsTrue(person.Role.Name == "admin");
            }
        }
    }
