using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWebApi.Data.NHibernate.Repository;
using MyWebApi.Ioc;
using MyWebApi.Mapping.Entities;
using MyWebApi.Models.Product;
using MyWebApi.Tests.Base;
using System.Linq;

namespace MyWebApi.Business.Tests
{
    [TestClass]
    public class ProductBusinessTest : BaseTest
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
            var productToInsert = new ProductModel("Meu Produto Test");

            var businessClass = new ProductBusiness(_repository.Object);
            businessClass.InsertNewProduct(productToInsert);

            var dataFromServiceLocator = ServiceLocator.Current.GetInstance<IRepository<Product>>().GetAll().ToList();

            _repository.Verify(x => x.Create(It.IsAny<Product>()), Times.Never);
            Assert.AreEqual(1, dataFromServiceLocator.Count);
        }


        [TestCleanup]
        public void TearDown()
        {
            _repository = null;
        }
    }
}
