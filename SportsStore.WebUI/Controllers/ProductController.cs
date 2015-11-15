using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;  //1.IOC 反转控制 
        
        public ProductController(IProductRepository productRepository) //2.IOC 反转控制 当调用ProductController控制器时ninject自动去根据bind实例化IProductRepository
        {
            repository = productRepository;
        }

        // GET: Product
        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}