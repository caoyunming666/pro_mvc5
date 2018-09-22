using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;


namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;

        public int PageSize = 4;

        /// <summary>
        ///构造函数
        /// </summary>
        /// <param name="productsRepository"></param>
        public ProductController(IProductsRepository productsRepository)
        {
            this.repository = productsRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(x => x.Category == null || x.Category == category)
                .OrderBy(x => x.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),

                PagingInfo = new PageInfoViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //TotalItems = repository.Products.Count()
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(x => x.Category == category).Count()
                },

                CurrentCategroy = category
            };

            //var list = repository.Products.OrderBy(x => x.Id).Skip((page - 1) * PageSize).Take(PageSize);
            return View(model);
        }
    }
}