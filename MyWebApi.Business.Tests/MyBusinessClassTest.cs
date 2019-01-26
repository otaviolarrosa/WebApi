using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWebApi.Data.NHibernate.Repository;
using MyWebApi.Ioc;
using MyWebApi.Mapping.Entities;
using MyWebApi.Tests.Base;
using System.Linq;

namespace MyWebApi.Business.Tests
{
    [TestClass]
    public class MyBusinessClassTest : BaseTest
    {
        private Mock<IRepository<Product>> _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new Mock<IRepository<Product>>();
        }

        [TestMethod]
        public void WillInsertTwoProductObjectsInDatabase()
        {
            var businessClass = new MyBusinessClass(_repository.Object);
            businessClass.MyBusinessMethod();

            var dataFromServiceLocator = ServiceLocator.Current.GetInstance<IRepository<Product>>().GetAll().ToList();

            _repository.Verify(x => x.Create(It.IsAny<Product>()), Times.Exactly(1));
            Assert.AreEqual(1, dataFromServiceLocator.Count);
        }


        [TestCleanup]
        public void TearDown()
        {
            _repository = null;
        }
    }
}
