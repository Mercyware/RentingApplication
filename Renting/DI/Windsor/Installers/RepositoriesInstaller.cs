using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Renting.Interface;
using Renting.Domain.Models;
using Castle.Core;
using Renting.Domain.Services;
using Renting.Repository.Services;

namespace Renting.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IEquipmentRepository))
                    .ImplementedBy(typeof(EquipmentRepository))
                    .Named("EquipmentRepository")
                    .LifeStyle.Is(LifestyleType.Singleton));
        }
    }
}