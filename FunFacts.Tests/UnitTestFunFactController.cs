using System;
using System.Linq;
using System.Web;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit;
using Moq;
using System.Collections.Generic;
using FunFacts;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace FunFacts.Tests
{
    [TestClass]
    public class UnitTestFunFactController
    {
        [TestMethod]
        public void GetTopNList()
        {

            //Arrange
            var list = new List<FunFacts.Models.FunFact>();
            list.Add(new FunFacts.Models.FunFact { id = 1, description = "1" });
            list.Add(new FunFacts.Models.FunFact { id = 2, description = "2" });
            list.Add(new FunFacts.Models.FunFact { id = 3, description = "3" });

            var mockList = new Mock<Models.IFunFacts>();
            mockList.Setup(x => x.GetTopN(2))
                .Returns(list.Take(2));

            var controller = new FunFacts.Controllers.FunFactsController(mockList.Object);

            //Act
            var actionREsult = controller.GetFunFactsTopN(2); 
            
            // Assert
            NUnit.Framework.Assert.IsNotNull(actionREsult);
            NUnit.Framework.Assert.AreEqual(2, actionREsult.ToList().Count());

        }

        [TestMethod]
        public void GetRandom()
        {

            //Arrange
            Models.IFunFact funfact = new Models.FunFact() { id = 1, description = "1" };
            var mockList = new Mock<Models.IFunFacts>();
            mockList.Setup(x => x.GetRandom())
                .Returns(Task.FromResult(funfact));

            var controller = new FunFacts.Controllers.FunFactsController(mockList.Object);
            

            //Act
            var actionResult = controller.GetFunFact();
            var contentResult = actionResult.Result as OkNegotiatedContentResult<Models.FunFact>;
            var content = contentResult.Content as Models.FunFact;

            // Assert
            NUnit.Framework.Assert.IsNotNull(actionResult);
            NUnit.Framework.Assert.AreEqual(1, content.id);

        }
    }
}
