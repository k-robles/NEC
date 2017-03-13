using System;
using System.Linq;
using System.Web;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using Moq;
using System.Collections.Generic;
using FunFacts.Models;
using FunFacts.BusinessLogic;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace FunFacts.Tests
{
    [TestClass]
    public class UnitTestFunFactController
    {
        [TestMethod]
        public void GetTop2OfListOf3()
        {

            //Arrange
            var list = new List<FunFact>();
            list.Add(new FunFact { id = 1, description = "1" });
            list.Add(new FunFact { id = 2, description = "2" });
            list.Add(new FunFact { id = 3, description = "3" });

            var mockList = new Mock<IFunFactsBL<FunFact>>();
            mockList.Setup(x => x.GetTopN(2)).Returns(list.Take(2));

            var controller = new FunFacts.Controllers.FunFactsController(mockList.Object);

            //Act
            var actionREsult = controller.GetFunFactsTopN(2); 
            
            // Assert
            Assert.IsNotNull(actionREsult);
            Assert.AreEqual(2, actionREsult.ToList().Count());

        }

        [TestMethod]
        public void GetRandomReturnsOKWithFunFact()
        {

            //Arrange
            var funfact = new FunFact() { id = 1, description = "1" };
            var mockList = new Mock<IFunFactsBL<FunFact>>();
            mockList.Setup(x => x.GetRandom()).Returns(Task.FromResult(funfact));

            var controller = new FunFacts.Controllers.FunFactsController(mockList.Object);
            

            //Act
            var actionResult = controller.GetFunFact();
            var contentResult = actionResult.Result as OkNegotiatedContentResult<FunFact>;
            var content = contentResult.Content as FunFact;

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(1, content.id);
        }

        [TestMethod]
        public void GetRandomReturnsNotFound()
        {

            //Arrange
            FunFact funfact = null;
            var mockList = new Mock<IFunFactsBL<FunFact>>();
            mockList.Setup(x => x.GetRandom()).Returns(Task.FromResult(funfact));

            var controller = new FunFacts.Controllers.FunFactsController(mockList.Object);

            //Act
            var actionResult = controller.GetFunFact();
            
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.Result.GetType(), typeof(NotFoundResult));
        }

        [TestMethod]
        public void CheckPutFunFactReturnOk()
        {

            //Arrange           
            var funfact = new FunFact() { id = 1, description = "funfact" };
            var mockList = new Mock<IFunFactsBL<FunFact>>();
            mockList.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<FunFact>()))
                .Returns(Task.FromResult(1));

            var controller = new FunFacts.Controllers.FunFactsController(mockList.Object);

            //Act
            var actionResult = controller.PutFunFact(1, funfact);
           
            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.Result.GetType(), typeof(StatusCodeResult));
        }

        [TestMethod]
        public void CheckPostFunFactReturnOk()
        {

            //Arrange           
            var funfact = new FunFact() { id = 1, description = "funfact" };
            var mockList = new Mock<IFunFactsBL<FunFact>>();
            mockList.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<FunFact>()))
                .Returns(Task.FromResult(1));

            var controller = new FunFacts.Controllers.FunFactsController(mockList.Object);

            //Act
            var actionResult = controller.PutFunFact(1, funfact);

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.Result.GetType(), typeof(StatusCodeResult));
        }

        [TestMethod]
        public void CheckDeleteFunFactReturnOk()
        {

            //Arrange                      
            var mockList = new Mock<IFunFactsBL<FunFact>>();
            mockList.Setup(x => x.Delete(It.IsAny<int>()))
                .Returns(Task.FromResult(1));

            var controller = new FunFacts.Controllers.FunFactsController(mockList.Object);

            //Act
            var actionResult = controller.DeleteFunFact(2);

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(actionResult.Result.GetType(), typeof(OkResult));
        }
    }
}
