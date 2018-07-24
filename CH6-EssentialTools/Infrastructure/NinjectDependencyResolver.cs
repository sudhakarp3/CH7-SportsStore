using CH6_EssentialTools.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Web.Common;


namespace CH6_EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("add binding 1...."));
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();

            System.Diagnostics.Debug.WriteLine(string.Format("add binding 2...."));
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("paramDiscount", 50m);
            System.Diagnostics.Debug.WriteLine(string.Format("add binding 3...."));
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();

        }
    }
}