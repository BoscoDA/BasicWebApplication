using BasicWebApplication.Controllers;
using BasicWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Moq;

namespace BasicWebApplicationTestProject
{
    [TestClass]
    public class AmpControllerTests
    {
        AmpController ampController;
        static AmpRepo repo;

        public AmpControllerTests()
        {
            if(repo == null)
                repo = new AmpRepo();
                ampController = new AmpController(repo);
        }

        [TestMethod]
        public void AmpControllerDetailTest()
        {
            //Arrange
            Amp amp = new Amp();
            repo.AddAmp(amp);
            //Act
            var result = (ViewResult)ampController.Index();
            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
            Assert.AreEqual(repo.Amps.GetType(), result.Model.GetType());
        }

        [TestMethod]
        public void AmpControllerCreateAmp()
        {
            //Arrange
            Amp amp = new Amp() { Model = "Fender Ultimate Chorous", PluggedIn=true,Powered=true};
            int ampCountPrev, ampCountAfterCreate;

            //Act
            ampCountPrev = repo.Amps.Count;
            var result = ampController.Create(amp);
            ampCountAfterCreate = repo.Amps.Count;

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual(ampCountPrev + 1, ampCountAfterCreate);
        }

        [TestMethod]
        public void AmpControllerDeleteAmp()
        {
            //Arrange
            Amp amp = new Amp() { Model = "Fender Ultimate Chorous", PluggedIn = true, Powered = true };
            int ampCountPrev, ampCountAfterDelete;
            IFormCollection collection = null;

            //Act
            ampController.Create(amp);
            ampCountPrev = repo.Amps.Count;
            var result = ampController.Delete(amp.ID,collection);
            ampCountAfterDelete = repo.Amps.Count;

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            Assert.AreEqual(ampCountPrev - 1, ampCountAfterDelete);
        }
    }
}