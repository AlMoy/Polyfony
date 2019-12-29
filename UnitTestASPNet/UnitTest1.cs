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
            List<T> list = repository.FindAllAsync();
            Assert.IsEmpty(list);
            return list;
            }

        [Test]
        public List<T> GetListFiltered<T>(Repository<T> repository, Dictionary<String, String> criteria, Dictionary<String, String> orderBy = null, ulong? limit = null, ulong? offset = null)
            {
            List<T> list = repository.FindByAsync(criteria, orderBy, limit, offset);
            Assert.IsEmpty(list);
            return list;
            }

        [Test]
        public void ToAccessAdmin(Person person)
            {
            Assert.IsTrue(person.Role.Name == "admin");
            }

        [Test]
        public void LoginTest()
            {//https://stackoverflow.com/questions/25718394/getting-error-cannot-convert-type-actionresult-to-viewresult-in-unit-testing
             // Arrange
            /*var loginModel = new LoginViewModel() { Email = "Admin@admin.com", Password = "admin123" };
            var controller = new AccountController();

            // Validate model state start
            var validationContext = new ValidationContext(loginModel, null, null);
            var validationResults = new List<ValidationResult>();

            //set validateAllProperties to true to validate all properties; if false, only required attributes are validated.
            Validator.TryValidateObject(loginModel, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
            // Validate model state end


            // Act

            var result =  controller.Login(loginModel, null) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);*/
        }

        [Test]
        public void EditSeller(ulong id)
            {
            //https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/unit-testing/creating-unit-tests-for-asp-net-mvc-applications-cs

            // Arrange
            /*PeopleController controller = new PeopleController();

            // Act
            ViewResult result =  controller.Edit(id) as ViewResult; 

            // Assert
            Assert.IsNotNull(result);*/
            }

        [Test]
        public void DeleteElement<T>(Repository<T> repository, ulong id)
            {
            repository.Remove(id);
            Assert.IsTrue(repository.Find(id) != null);
            }

        [Test]
        public void FindElement<T>(Repository<T> repository, ulong id) 
            {
            Assert.IsNotNull(repository.Find(id));
            }

        [Test]
        public void CreateElement<T>(Repository<T> repository, T element)
            {
            Assert.IsNotNull(repository.Create(element));
            }
        }
    }
