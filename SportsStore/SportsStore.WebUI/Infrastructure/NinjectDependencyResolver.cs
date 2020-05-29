
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using System.Configuration;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel KernelParam)
        {
            kernel = KernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {

            new Product {Name="Football" ,Price= 23} ,
             new Product {Name="Caram board" ,Price= 293},
              new Product {Name="Running Shoes" ,Price= 20}

            });
          //  kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            EmailSetting emailSetting = new EmailSetting
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")

            };

            kernel.Bind<IorderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("setting", emailSetting);
        }
        public object GetService(Type serviceType)
        {

            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}