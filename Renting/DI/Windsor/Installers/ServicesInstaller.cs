using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Renting.Interface;
using Renting.Domain.Models;
using Castle.Core;
using Renting.Domain.Services;

namespace Renting.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IEquipmentService))
                    .ImplementedBy(typeof(EquipmentService))
                    .Named("EquipmentService")
                    .LifeStyle.Is(LifestyleType.Singleton));
        }
    }
}