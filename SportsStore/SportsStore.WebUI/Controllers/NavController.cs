using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    /// <summary>
    /// 导航菜单
    /// </summary>
    public class NavController : Controller
    {
        private IProductsRepository repository;

        /// <summary>
        /// 构造函数
        /// </summary>
        public NavController(IProductsRepository repo)
        {
            this.repository = repo;
        }

        //public string Menu()
        //{
        //    return "Hello from NavController";
        //}
        //public PartialViewResult Menu(string category = null, bool horizontalLayout = false)
        //{
        //    ViewBag.SelectedCategory = category;
        //    IEnumerable<string> categories = repository.Products
        //        .Select(x => x.Category)
        //        .Distinct()
        //        .OrderBy(x => x);
        //    string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
        //    return PartialView(viewName, categories);
        //}

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView("FlexMenu", categories);
        }
    }
}