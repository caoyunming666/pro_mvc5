using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;

namespace SportsStore.WebUI.InfrastructureDI
{
    /// <summary>
    /// Ninject 依赖解析器
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// 内核
        /// </summary>
        private IKernel kernel;

        /// <summary>
        /// 构造函数
        /// </summary>
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            this.kernel = kernelParam;
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

        /// <summary>
        /// 添加绑定
        /// </summary>
        private void AddBindings()
        {
            //添加假数据
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(x => x.Products).Returns(new List<Product>
            //{
            //    new Product { Name="足球",Price=25 },
            //    new Product { Name="篮球",Price=179 },
            //    new Product { Name="橄榄球",Price=95 },
            //});
            //kernel.Bind<IProductsRepository>().ToConstant(mock.Object);

            kernel.Bind<IProductsRepository>().To<EFProductRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false"),
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
        }
    }
}