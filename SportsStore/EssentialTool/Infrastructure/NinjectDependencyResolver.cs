using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EssentialTool.Models;
using Ninject;
using System.Web.Mvc;
namespace EssentialTool.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
       public NinjectDependencyResolver(IKernel kernelParam)
        {

            Kernel = kernelParam;
           AddBindings();
        }

        private IKernel Kernel;
        private void AddBindings()
        {
            Kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            Kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 10000M);
        }
        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }
}