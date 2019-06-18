using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Renting.Interface;
using Renting.Domain.Models;
using Castle.Core;
using Renting.Interface.Factory;
using Renting.Domain.Factory;

namespace Renting.Installers
{
    public class FactoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IEquipmentFactory))
                    .ImplementedBy(typeof(EquipmentFactory))
                    .Named("EquipmentFactory")
                    .LifeStyle.Is(LifestyleType.Singleton));
        }
    }
}