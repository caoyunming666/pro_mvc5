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
    /// <summary>
    /// 加入购物车
    /// </summary>
    public class CartController : Controller
    {
        private IProductsRepository repository;

        public CartController(IProductsRepository repo)
        {
            this.repository = repo;
        }


        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }


        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(int id, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// 从购物车删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFormCart(int id, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        /// <summary>
        /// 获取购物车信息
        /// </summary>
        private ShopCart GetCart()
        {
            ShopCart cart = (ShopCart)Session["Cart"];
            if (cart == null)
            {
                cart = new ShopCart();

                /* 
                 * session对象默认存储在asp.net服务器的内存中，但你可以配置不同的存储方式，包括使用一个sql数据库
                 *  ：留意这方面的技术文章
                 */
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}