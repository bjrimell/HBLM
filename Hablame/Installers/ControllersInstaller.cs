using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

using Hablame.Services;
using Hablame.Repositories;

namespace Hablame.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());

            // Services
            container.Register(Component.For<IFriendService>().ImplementedBy<FriendService>().LifestylePerWebRequest());

            container.Register(Component.For<ITalkService>().ImplementedBy<TalkService>().LifestylePerWebRequest());

            container.Register(Component.For<IMistakeService>().ImplementedBy<MistakeService>().LifestylePerWebRequest());

            // Repos
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IMistakeRepository>().ImplementedBy<MistakeRepository>().LifestylePerWebRequest());
        }
    }
}