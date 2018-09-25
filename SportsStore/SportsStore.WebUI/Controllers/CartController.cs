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
        private IOrderProcessor orderProcessor;

        public CartController(IProductsRepository repo, IOrderProcessor proc)
        {
            this.repository = repo;
            this.orderProcessor = proc;
        }


        public ViewResult Index(ShopCart cart, string returnUrl)
        {
            //return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }


        /// <summary>
        /// 添加到购物车
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(ShopCart cart, int id, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                //GetCart().AddItem(product, 1);
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// 从购物车删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFormCart(ShopCart cart, int id, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                //GetCart().RemoveLine(product);
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        /// <summary>
        /// 显示购物车摘要
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public PartialViewResult Summary(ShopCart cart)
        {
            return PartialView(cart);
        }


        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(ShopCart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "购物车是空的");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }


        //把生成cart对象的回话单独放在一个代码文件中，这样可以方便的对当前控制器进行单元测试
        ///// <summary>
        ///// 获取购物车信息
        ///// </summary>
        //private ShopCart GetCart()
        //{
        //    ShopCart cart = (ShopCart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new ShopCart();
        //        /* 
        //         * session对象默认存储在asp.net服务器的内存中，但你可以配置不同的存储方式，包括使用一个sql数据库
        //         *  ：留意这方面的技术文章
        //         */
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}