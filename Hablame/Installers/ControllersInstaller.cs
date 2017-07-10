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

            container.Register(Component.For<IConversationService>().ImplementedBy<ConversationService>().LifestylePerWebRequest());

            container.Register(Component.For<IMistakeService>().ImplementedBy<MistakeService>().LifestylePerWebRequest());

            container.Register(Component.For<ILanguageService>().ImplementedBy<LanguageService>().LifestylePerWebRequest());

            // Repos
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IMistakeRepository>().ImplementedBy<MistakeRepository>().LifestylePerWebRequest());

            container.Register(Component.For<IConversationRepository>().ImplementedBy<ConversationRepository>().LifestylePerWebRequest());
        }
    }
}