using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HotelTamagotchi.Domain.Repository;
using HotelTamagotchi.Controllers;
using System.Web.Mvc;
using System.Data.Entity;
using HotelTamagotchi.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using HotelTamagotchi.Models.ViewModel;

namespace HotelTamagotchi.Tests.Controllers
{
    [TestClass]
    public class TamagotchiControllerTest
    {

        [TestMethod]
        public void TamagotchiControllerIndexViewNotNull()
        {
            // Arrange
            var tamagotchiRepo = new Mock<TamagotchiRepository>();
            var userRepo = new Mock<PlayerUserRepository>();
            var controller = new TamagotchiController(tamagotchiRepo.Object, userRepo.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

                
      


        [TestMethod]
        public void TamagotchiControllerCreate()
        {
            // Arrange
            var tamagotchiVM = new TamagotchiVM();
            var tamagotchiRepo = new Mock<TamagotchiRepository>();
            var userRepo = new Mock<PlayerUserRepository>();

            var controller = new TamagotchiController(tamagotchiRepo.Object, userRepo.Object);

            // Act
            tamagotchiVM.Name = "Test";
            tamagotchiVM.IsALive = true;
            tamagotchiVM.Age = 0;
            tamagotchiVM.Money = 100;
            tamagotchiVM.Level = 0;
            tamagotchiVM.Health = 100;
            tamagotchiVM.Boredom = 0;
            tamagotchiVM.PlayerUserId = 1;

            controller.Create(tamagotchiVM);
            var lastDatabaseItem = tamagotchiRepo.Object.GetAll().LastOrDefault();

            // Assert
            Assert.AreEqual(lastDatabaseItem.Name, tamagotchiVM.Name);
        }

        [TestMethod]
        public void TamagotchiControllerDetail()
        {
            // Arrange
            var tamagotchiRepo = new Mock<TamagotchiRepository>();
            var userRepo = new Mock<PlayerUserRepository>();
            var controller = new TamagotchiController(tamagotchiRepo.Object, userRepo.Object);

            // Act
            var lastDatabaseItem = tamagotchiRepo.Object.GetAll().LastOrDefault();


            // Assert
            if (lastDatabaseItem != null)
            {
                ViewResult result = controller.Details(lastDatabaseItem.TamagotchiId) as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }
            else
            {
                ViewResult result = controller.Details(null) as ViewResult;

                // Assert
                Assert.IsNull(result);
            }

        }

        [TestMethod]
        public void TamagotchiControllerEdit()
        {
            // Arrange
            var tamagotchiRepo = new Mock<TamagotchiRepository>();
            var userRepo = new Mock<PlayerUserRepository>();
            var controller = new TamagotchiController(tamagotchiRepo.Object, userRepo.Object);

            var tamagotchi = tamagotchiRepo.Object.GetAll().LastOrDefault();

            if (tamagotchi != null)
            {
                var tamagotchiVM = new TamagotchiVM(tamagotchi);
                // Act
                tamagotchiVM.Age = 100;

                controller.Edit(tamagotchiVM);
                var lastDatabaseItem = tamagotchiRepo.Object.GetAll().LastOrDefault();

                // Assert
                Assert.AreEqual(lastDatabaseItem.Age, tamagotchiVM.Age);
            }
            else
            {
                Assert.IsNull(tamagotchi);
            }

        }


        [TestMethod]
        public void TamagotchiControllerDelete()
        {
            // Arrange
            var tamagotchiRepo = new Mock<TamagotchiRepository>();
            var userRepo = new Mock<PlayerUserRepository>();
            var controller = new TamagotchiController(tamagotchiRepo.Object, userRepo.Object);

            // Act
            var deleteItem = tamagotchiRepo.Object.GetAll().LastOrDefault();

            if (deleteItem == null)
            {
                Assert.IsNull(deleteItem);
            }
            else
            {
                controller.DeleteConfirmed(deleteItem.TamagotchiId);
                var lastDatabaseItem = tamagotchiRepo.Object.GetAll().LastOrDefault();

                // Assert
                if (lastDatabaseItem == null)
                {
                    Assert.IsNull(lastDatabaseItem);
                }
                else
                {
                    Assert.AreNotEqual(lastDatabaseItem.TamagotchiId, deleteItem.TamagotchiId);
                }

            }
        }
    }
}
