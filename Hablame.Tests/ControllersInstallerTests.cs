//using Castle.Windsor;
//using Hablame.Installers;
//using Castle.Core;
//using Castle.MicroKernel.Context;

//using Xunit;
//using System;

//namespace Hablame.Tests
//{
//    class ControllersInstallerTests
//    {

// see this page for setup of tests:
// hhttps://github.com/castleproject/Windsor/blob/master/docs/mvc-tutorial-part-3a-testing-your-first-installer.md

//        private IWindsorContainer containersWithControllers;

//        public ControllersInstallerTests()
//        {
//            containersWithControllers = new WindsorContainer()
//                .Install(new ControllersInstaller());
//        }

//        [Fact]
//        public void All_controllers_implement_IController()
//        {
//            var allHandlers = GetAllHandlers(containersWithControllers);
//            var controllerHandlers = GetHandlersFor(typeof(IController), containersWithControllers);

//            Assert.NotEmpty(allHandlers);
//            Assert.Equal(allHandlers, controllerHandlers);
//        }

//        private IHandler[] GetAllHandlers(IWindsorContainer container)
//        {
//            return GetHandlersFor(typeof(object), container);
//        }

//        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
//        {
//            return container.Kernel.GetAssignableHandlers(type);
//        }

//    }
//}
