using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Renting;
using Renting.Controllers;
using NUnit.Framework;
using Renting.Domain.Models;
using Renting.Interface;
using Renting.Repository.Models;
using Rhino.Mocks;

namespace Renting.Tests.Controllers
{
   [TestFixture, Category("Controllers")]
    public class HomeControllerTest
    {
        private IEquipmentService equipmentService;


        private HomeController homeController;

        private IEquipmentViewModel equipmentViewModel;
        private IEnumerable<EquipmentModel> equipmentList;

        [SetUp]
        public void Setup()
        {
            this.equipmentService = MockRepository.GenerateMock<IEquipmentService>();
            this.homeController = new HomeController(this.equipmentService);

            this.equipmentViewModel = new EquipmentViewModel
            {
                Equipments = equipmentList
            };

         
        }


        [Test]
        public  void Index_Calls_GetEquipmentViewModel_from_EquipmentService_Successfully()
        {
            //Setup
            this.equipmentService.Expect(p => p.GetEquipmentViewModel()).IgnoreArguments()
                .Return(equipmentViewModel);

            //Act
             this.homeController.Index();


            //Assert
            this.equipmentService.VerifyAllExpectations();
        }

        [Test]
        public void Test_That_Index_Returns_A_ViewResult_That_Is_Not_Null()
        {
            //Setup
            this.equipmentService.Expect(p => p.GetEquipmentViewModel()).IgnoreArguments()
                .Return(equipmentViewModel);

            // Act
            ViewResult result =  this.homeController.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


     
    }
  
}
