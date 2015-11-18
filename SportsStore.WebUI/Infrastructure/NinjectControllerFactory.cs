using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        
        protected override IController GetControllerInstance(RequestContext requestContext,Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }


        /// <summary>
        /// 绑定接口和实现类
        /// </summary>
        private void AddBindings()
        {
            ////创建模仿存储库
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>{
            //    new Product{Name="Football",Price=25},
            //    new Product{Name="Surf board",Price=179},
            //new Product{Name="Running shoes",Price=95}}.AsQueryable());
            //ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);//每次都会模仿该对象来满足接口，而不是每次都创建一个新的实现对象实例

            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
        }
    }
}