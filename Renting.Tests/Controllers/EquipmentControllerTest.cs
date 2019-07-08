using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using Renting.Controllers;
using Renting.Domain.Models;
using Renting.Interface;
using Renting.Repository.Models;
using Rhino.Mocks;

namespace Renting.Tests.Controllers
{
    [TestFixture, Category("Controllers")]
    public class EquipmentControllerTest
    {
        private IEquipmentService equipmentService;

        private EquipmentController equipmentController;
        private HomeController homeController;
        private IEquipmentViewModel equipmentViewModel;
        private IEnumerable<EquipmentModel> equipmentList;
        private IEquipmentModel equipment;


        [SetUp]
        public void Setup()
        {
            this.equipmentService = MockRepository.GenerateMock<IEquipmentService>();
            this.equipmentController = new EquipmentController(this.equipmentService);
            this.homeController = new HomeController(this.equipmentService);
            this.equipmentViewModel = new EquipmentViewModel
            {
                Equipments = equipmentList
            };

            this.equipment = new EquipmentModel
            {
                EquipmentID = 1,
                EquipmentName = "test Equipment",
                EquipmentType = "test Type",
                DaysOfHire = 1,
            };
        }


        [Test]
        public void AddCart_Post_Should_Throw_Exception_When_Equipment_Is_Null()
        {
            // Arrange
            EquipmentModel equipmentModel = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => this.equipmentController.AddToCart(equipmentModel));
        }


        [Test]
        public void AddToCart_Post_Calls_AddToCart_From_EquipmentService_Successfully()
        {
            //setup
            this.equipmentService.Expect(p => p.AddToCart(new EquipmentModel())).IgnoreArguments();

            //Act
            this.equipmentController.AddToCart(new EquipmentModel());


            //Assert
            this.equipmentService.VerifyAllExpectations();
        }

        [Test]
        public void AddToCart_Post_Should_Redirect_To_Controller_Home_When_All_Is_Okay()
        {
            // Arrange
            this.equipmentService.Expect(p => p.AddToCart(new EquipmentModel())).IgnoreArguments();

            // Act
            var result = (RedirectToRouteResult) this.equipmentController.AddToCart(new EquipmentModel());

            // Assert
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }


        [Test]
        public void RemoveFromCart_Post_Should_Throw_Exception_When_EquipmentID_Is_Invalid()
        {
            // Arrange
            int equipmentId = 0;

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.equipmentController.RemoveFromCart(equipmentId));
        }


        [Test]
        public void RemoveFromCart_Post_Calls_RemoveFromCart_From_EquipmentService_Successfully()
        {
            int equipmentId = 1;

            //setup
            this.equipmentService.Expect(p => p.RemoveFromCart(equipmentId)).IgnoreArguments();

            //Act
            this.equipmentController.RemoveFromCart(equipmentId);


            //Assert
            this.equipmentService.VerifyAllExpectations();
        }

        [Test]
        public void RemoveFromCart_Post_Should_Redirect_To_Controller_Home_When_All_Is_Okay()
        {
            // Arrange
            int equipmentId = 1;

            this.equipmentService.Expect(p => p.RemoveFromCart(equipmentId)).IgnoreArguments();

            // Act
            var result = (RedirectToRouteResult) this.equipmentController.RemoveFromCart(equipmentId);

            // Assert
            Assert.AreEqual("Equipment", result.RouteValues["controller"]);
        }


        [Test]
        public void Cart_Get_Method_Calls_GetEquipmentCartModel_From_EquipmentService_Successfully()
        {
            //setup
            var message = "test message";
            this.equipmentService.Expect(p => p.GetEquipmentCartModel(message)).IgnoreArguments()
                .Return(new EquipmentCartViewModel());

            //Act
            this.equipmentController.Cart(message);


            //Assert
            this.equipmentService.VerifyAllExpectations();
        }

        [Test]
        public void Cart_Get_Should_Return_Cart_View_Successfully()
        {
            // Arrange
            var message = "test message";
            var viewModel = new EquipmentCartViewModel();
            this.equipmentService.Expect(p => p.GetEquipmentCartModel(message)).IgnoreArguments().Return(viewModel);

            //Act
            var result = (ViewResult) equipmentController.Cart(message);

            // Assert
            Assert.AreEqual(result.ViewName, "Cart");
        }


        [Test]
        public void SearchEquipment_Post_Calls_SearchEquipment_From_EquipmentService_Successfully()
        {
            string equipmentDescription = "testDescription";

            //setup
            this.equipmentService.Expect(p => p.SearchEquipment(equipmentDescription)).IgnoreArguments().Return(new EquipmentViewModel());

            //Act
            this.equipmentController.SearchEquipment(equipmentDescription);


            //Assert
            this.equipmentService.VerifyAllExpectations();
        }


        [Test]
        public void SearchEquipment_Get_Should_Return_SearchEquipment_View_Successfully()
        {
            // Arrange
            var equipmentDescription = "testDescription";
            this.equipmentService.Expect(p => p.SearchEquipment(equipmentDescription)).IgnoreArguments().Return(new EquipmentViewModel());

            //Act
            var result = (ViewResult)equipmentController.SearchEquipment(equipmentDescription);

            // Assert
            Assert.AreEqual(result.ViewName, "SearchEquipment");
        }


        [Test]
        public void DownloadInvoice_Calls_GenerateInvoice_From_EquipmentService_Successfully()
        {

            //setup
            this.equipmentService.Expect(p => p.GenerateInvoice()).IgnoreArguments().Return(new System.IO.MemoryStream());

            //Act
            this.equipmentController.DownloadInvoice();


            //Assert
            this.equipmentService.VerifyAllExpectations();
        }

        [Test]
        public void DownloadInvoice_ReturnFiles_Successfully()
        {
            // Arrange
            this.equipmentService.Expect(p => p.GenerateInvoice()).IgnoreArguments().Return(new System.IO.MemoryStream());

            // Act
            var result = (FileStreamResult)this.equipmentController.DownloadInvoice();

            // Assert
            Assert.AreEqual(result.ContentType, "text/plain");
        }
    }
}