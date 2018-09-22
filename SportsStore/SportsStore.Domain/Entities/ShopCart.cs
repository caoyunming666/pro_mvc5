/**
* 命名空间: SportsStore.Domain.Entities
*
* 功 能： N/A
* 类 名： ShopCart
* CLR V:  4.0.30319.42000
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/9/22 15:21:39 PC-CAOYUNMING
*/

using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Entities
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class ShopCart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        /// <summary>
        /// 添加商品至购物车
        /// </summary>
        /// <param name="product"></param>
        /// <param name="count"></param>
        public void AddItem(Product product, int count)
        {
            CartLine cl = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (cl == null)
            {
                lineCollection.Add(new CartLine { Product = product, Count = count });
            }
            else
            {
                cl.Count += count;
            }
        }

        /// <summary>
        /// 移除购物车中的商品
        /// </summary>
        /// <param name="product"></param>
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(x => x.Product.Id == product.Id);
        }

        /// <summary>
        /// 计算总价
        /// </summary>
        public decimal ComputeToValue()
        {
            return lineCollection.Sum(x => x.Product.Price * x.Count);
        }

        /// <summary>
        /// 清空购物车
        /// </summary>
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lineCollection;
            }
        }

    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
