using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HotelTamagotchi.Domain.Repository;
using HotelTamagotchi.Controllers;
using System.Web.Mvc;
using System.Linq;
using HotelTamagotchi.Models.ViewModel;

namespace HotelTamagotchi.Tests.Controllers
{
    [TestClass]
    public class HotelRoomsControllerTest
    {

        [TestMethod]
        public void HotelRoomsControllerIndexViewNotNull()
        {
            // Arrange
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var hotelroomTypeRepo = new Mock<HotelRoomTypeRepository>();
            var hotelroomSizeRepo = new Mock<HotelRoomSizeRepository>();

            var controller = new HotelRoomsController(hotelroomRepo.Object, hotelroomTypeRepo.Object, hotelroomSizeRepo.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void HotelRoomsControllerCreate()
        {
            // Arrange
            var hotelroomVM = new HotelRoomVM();
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var hotelroomTypeRepo = new Mock<HotelRoomTypeRepository>();
            var hotelroomSizeRepo = new Mock<HotelRoomSizeRepository>();

            var controller = new HotelRoomsController(hotelroomRepo.Object, hotelroomTypeRepo.Object, hotelroomSizeRepo.Object);

            // Act
            hotelroomVM.HotelRoomName = "Test";
            hotelroomVM.RoomSize = 2;
            hotelroomVM.RoomType = "Love room";

            controller.Create(hotelroomVM);
            var lastDatabaseItem = hotelroomRepo.Object.GetAll().LastOrDefault();

            // Assert
            Assert.AreEqual(lastDatabaseItem.HotelRoomName, hotelroomVM.HotelRoomName);
        }

        [TestMethod]
        public void HotelRoomsControllerDetail()
        {
            // Arrange
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var hotelroomTypeRepo = new Mock<HotelRoomTypeRepository>();
            var hotelroomSizeRepo = new Mock<HotelRoomSizeRepository>();

            var controller = new HotelRoomsController(hotelroomRepo.Object, hotelroomTypeRepo.Object, hotelroomSizeRepo.Object);

            // Act
            var lastDatabaseItem = hotelroomRepo.Object.GetAll().LastOrDefault();


            // Assert
            if (lastDatabaseItem != null)
            {
                ViewResult result = controller.Details(lastDatabaseItem.HotelRoomId) as ViewResult;

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
        public void HotelRoomsControllerEdit()
        {
            // Arrange
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var hotelroomTypeRepo = new Mock<HotelRoomTypeRepository>();
            var hotelroomSizeRepo = new Mock<HotelRoomSizeRepository>();

            var hotelroom = hotelroomRepo.Object.GetAll().LastOrDefault();

            if (hotelroom != null)
            {
                var hotelroomVM = new HotelRoomVM(hotelroom);

                var controller = new HotelRoomsController(hotelroomRepo.Object, hotelroomTypeRepo.Object, hotelroomSizeRepo.Object);

                // Act
                hotelroomVM.HotelRoomName = "Test";

                controller.Edit(hotelroomVM);
                var lastDatabaseItem = hotelroomRepo.Object.GetAll().LastOrDefault();

                // Assert
                Assert.AreEqual(lastDatabaseItem.HotelRoomName, hotelroomVM.HotelRoomName);
            }
            else
            {
                Assert.IsNull(hotelroom);
            }
          
        }

        [TestMethod]
        public void HotelRoomsControllerDelete()
        {
            // Arrange
            var hotelroomVM = new HotelRoomVM();
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var hotelroomTypeRepo = new Mock<HotelRoomTypeRepository>();
            var hotelroomSizeRepo = new Mock<HotelRoomSizeRepository>();

            var controller = new HotelRoomsController(hotelroomRepo.Object, hotelroomTypeRepo.Object, hotelroomSizeRepo.Object);

            // Act
            var deleteItem = hotelroomRepo.Object.GetAll().LastOrDefault();


            if (deleteItem == null)
            {
                Assert.IsNull(deleteItem);
            }
            else
            {
                controller.DeleteConfirmed(deleteItem.HotelRoomId);

                var lastDatabaseItem = hotelroomRepo.Object.GetAll().LastOrDefault();

                // Assert

                if (lastDatabaseItem == null)
                {
                    Assert.IsNull(lastDatabaseItem);
                }
                else
                {
                    Assert.AreNotEqual(lastDatabaseItem.HotelRoomId, deleteItem.HotelRoomId);
                }

            }

        }
    }
}
