using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
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
        public int pageSize = 4;
        
        public ProductController(IProductRepository productRepository) //2.IOC 反转控制 当调用ProductController控制器时ninject自动去根据bind实例化IProductRepository
        {
            repository = productRepository;
        }

        // GET: Product
        public ViewResult List(int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel();
            model.Products = repository.Products.OrderBy(p => p.ProductID).Skip(pageSize * (page - 1)).Take(pageSize);
            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = repository.Products.Count()
            };
            return View(model);
        }
    }
}