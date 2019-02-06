using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyWebApi.Business.Product;
using MyWebApi.Data.NHibernate.Repository;
using MyWebApi.Ioc;
using EntityProduct = MyWebApi.Mapping.Entities.Product;
using MyWebApi.Models.Product;
using MyWebApi.Tests.Base;
using System.Linq;

namespace MyWebApi.Business.Tests
{
    [TestClass]
    public class ProductBusinessTest : BaseTest
    {
        private Mock<IRepository<EntityProduct>> _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new Mock<IRepository<EntityProduct>>();
        }

        [TestMethod]
        public void WillInsertTwoProductObjectsInDatabase()
        {
            var productToInsert = new ProductModel("Meu Produto Test");

            var businessClass = new ProductBusiness(_repository.Object);
            businessClass.InsertNewProduct(productToInsert);

            var dataFromServiceLocator = ServiceLocator.Current.GetInstance<IRepository<EntityProduct>>().GetAll().ToList();

            _repository.Verify(x => x.Create(It.IsAny<EntityProduct>()), Times.Never);
            Assert.AreEqual(1, dataFromServiceLocator.Count);
        }


        [TestCleanup]
        public void TearDown()
        {
            _repository = null;
        }
    }
}
