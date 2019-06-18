using System.Collections.Generic;
using NUnit.Framework;
using Renting.Domain.Models;
using Renting.Domain.Services;
using Renting.Interface;
using Renting.Interface.Factory;
using Renting.Repository.Models;
using Rhino.Mocks;

namespace Renting.Tests.Domain.Service
{
    [TestFixture]
    public class EquipmentServiceTest
    {
        private IEquipmentFactory equipmentFactory;
        private IEquipmentRepository equipmentRepository;
        private IEquipmentCartViewModel equipmentCartViewModel;
        private IEquipmentViewModel equipmentViewModel;
        private IEquipmentService iEquipmentService;
        private EquipmentService equipmentService;
        private IEnumerable<EquipmentModel> equipmentList;

        [SetUp]
        public void Setup()
        {
            this.equipmentFactory = MockRepository.GenerateMock<IEquipmentFactory>();
            this.iEquipmentService = MockRepository.GenerateMock<IEquipmentService>();
            this.equipmentRepository = MockRepository.GenerateMock<IEquipmentRepository>();

            this.equipmentList = new List<EquipmentModel>();
            this.equipmentService = new EquipmentService(this.equipmentRepository, this.equipmentFactory);
        }


        [Test]
        public void GetEquipmentViewModel_Should_call_GetMachinesList_From_EquipmentRepository()
        {
            //setup
            this.equipmentRepository.Expect(p => p.GetMachinesList()).IgnoreArguments().Return(equipmentList);
            
            //act
            this.equipmentService.GetEquipmentViewModel();
           
            //assert
            this.equipmentRepository.VerifyAllExpectations();
        }

        [Test]
        public void GetEquipmentViewModel_Should_call_CreateEquipmentView_From_EquipmentFactory_Successfuly()
        {
            //setup
            this.equipmentRepository.Stub(p => p.GetMachinesList()).IgnoreArguments().Return(equipmentList);
             this.equipmentFactory.Expect(p => p.CreateEquipmentView(this.equipmentList)).IgnoreArguments().Return(new EquipmentViewModel());
          
             //act
            this.equipmentService.GetEquipmentViewModel();
           
            //assert
            this.equipmentRepository.VerifyAllExpectations();
        }



        [Test]
        public void SearchEquipment_Should_call_GetMachinesList_From_EquipmentRepository()
        {
            //setup
            this.equipmentRepository.Expect(p => p.GetMachinesList()).IgnoreArguments().Return(equipmentList);

            //act
            this.equipmentService.GetEquipmentViewModel();

            //assert
            this.equipmentRepository.VerifyAllExpectations();
        }



        [Test]
        public void SearchEquipment_Should_call_CreateEquipmentView_From_EquipmentFactory_Successfuly()
        {
            //setup
            this.equipmentRepository.Stub(p => p.GetMachinesList()).IgnoreArguments().Return(equipmentList);
            this.equipmentFactory.Expect(p => p.CreateEquipmentView(this.equipmentList)).IgnoreArguments().Return(new EquipmentViewModel());

            //act
            this.equipmentService.GetEquipmentViewModel();

            //assert
            this.equipmentRepository.VerifyAllExpectations();
        }


        [Test]
        public void GetEquipmentCartModel_Should_call_CreateEquipmentView_From_EquipmentFactory_Successfully()
        {
            //setup
            this.equipmentFactory.Expect(p => p.CreateEquipmentView(this.equipmentList)).IgnoreArguments().Return(new EquipmentViewModel());

            //act
            this.equipmentService.GetEquipmentViewModel();

            //assert
            this.equipmentRepository.VerifyAllExpectations();
        }

    }
}