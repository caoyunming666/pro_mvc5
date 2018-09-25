using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;
using System.Web.Mvc;

namespace SportsStore.WebUI.InfrastructureDI.Binders
{
    /// <summary>
    /// 创建自定义模型绑定器：需要实现 IModelBinder 接口
    /// </summary>
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ShopCart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (ShopCart)controllerContext.HttpContext.Session[sessionKey];
            }
            if (cart == null)
            {
                cart = new ShopCart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}