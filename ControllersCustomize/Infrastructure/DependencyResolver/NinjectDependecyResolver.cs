using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersCustomize.Infrastructure.DependencyResolver
{
    public class NinjectDependecyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public IKernel Kernel
        {
            get
            {
                return this.kernel;
            }
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return this.kernel.Bind<T>();
        }

        public NinjectDependecyResolver()
        {
            this.kernel = new StandardKernel();
            this.AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            this.Bind<IProductRepository>().To<ProductRepository>();
            this.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}