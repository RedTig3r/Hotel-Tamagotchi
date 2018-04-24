using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HotelTamagotchi.Domain.Repository;
using HotelTamagotchi.Controllers;
using System.Web.Mvc;
using HotelTamagotchi.Models.RoomFactory;
using System.Linq;
using HotelTamagotchi.Models.ViewModel;
using System.Net;

namespace HotelTamagotchi.Tests.Controllers
{
    [TestClass]
    public class HotelBookingControllerTest
    {
        [TestMethod]
        public void HotelBookingControllerIndexViewNotNull()
        {
            // Arrange
            var hotelbookingRepo = new Mock<HotelBookingRepository>();
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var tamagotchiRepo = new Mock<TamagotchiRepository>();

            var controller = new HotelBookingController(hotelbookingRepo.Object, hotelroomRepo.Object, tamagotchiRepo.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }




        [TestMethod]
        public void HotelBookingControllerCreate()
        {
            // Arrange
            var hotelbookingRepo = new Mock<HotelBookingRepository>();
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var tamagotchiRepo = new Mock<TamagotchiRepository>();
            var controller = new HotelBookingController(hotelbookingRepo.Object, hotelroomRepo.Object, tamagotchiRepo.Object);

            var hotelbookingVM = new HotelBookingVM();


            var hotelrooms = hotelroomRepo.Object.GetAllHotelRoomsWhereBookingIsNull().ToList();
            if (hotelrooms != null)
            {
                // Act 
                hotelbookingVM.HotelRoomId = hotelrooms[0].HotelRoomId;
                hotelbookingVM.TamagotchisIds = new int[] { 1, 2 };

                controller.Create(hotelbookingVM);

                var lastDatabaseItem = hotelbookingRepo.Object.GetAll().LastOrDefault();

                // Assert
                Assert.AreEqual(lastDatabaseItem.HotelRoomId, hotelbookingVM.HotelRoomId);
            }
            else
            {
                Assert.IsNull(hotelrooms);
            }

        }

        [TestMethod]
        public void HotelBookingControllerDetail()
        {
            // Arrange
            var hotelbookingRepo = new Mock<HotelBookingRepository>();
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var tamagotchiRepo = new Mock<TamagotchiRepository>();

            var controller = new HotelBookingController(hotelbookingRepo.Object, hotelroomRepo.Object, tamagotchiRepo.Object);

            // Act
            var lastDatabaseItem = hotelbookingRepo.Object.GetAll().LastOrDefault();

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
        public void HotelBookingControllerEdit()
        {
            // Arrange
            var hotelbookingRepo = new Mock<HotelBookingRepository>();
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var tamagotchiRepo = new Mock<TamagotchiRepository>();

            var controller = new HotelBookingController(hotelbookingRepo.Object, hotelroomRepo.Object, tamagotchiRepo.Object);
            
            var hotelbooking = hotelbookingRepo.Object.GetAll().LastOrDefault();
            if (hotelbooking != null)
            {

                var hotelbookingVM = new HotelBookingVM(hotelbooking);
                //Act
                hotelbookingVM.TamagotchisIds = new int[] { 1, 2 };

                controller.Edit(hotelbookingVM);

                var lastDatabaseItem = hotelbookingRepo.Object.GetAll().LastOrDefault();

                // Assert
                Assert.AreEqual(lastDatabaseItem.HotelRoom.HotelRoomName, hotelbookingVM.HotelRoomName);
            }
            else
            {
                Assert.IsNull(hotelbooking);
            }
        }

        [TestMethod]
        public void HotelBookingControllerDelete()
        {

            // Arrange
            var hotelbookingRepo = new Mock<HotelBookingRepository>();
            var hotelroomRepo = new Mock<HotelRoomRepository>();
            var tamagotchiRepo = new Mock<TamagotchiRepository>();

            var controller = new HotelBookingController(hotelbookingRepo.Object, hotelroomRepo.Object, tamagotchiRepo.Object);

            // Act 

            var deleteItem = hotelbookingRepo.Object.GetAll().LastOrDefault();

            if (deleteItem == null)
            {
                Assert.IsNull(deleteItem);
            }
            else
            {
                controller.DeleteConfirmed(deleteItem.HotelRoomId);

                var lastDatabaseItem = hotelbookingRepo.Object.GetAll().LastOrDefault();

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
