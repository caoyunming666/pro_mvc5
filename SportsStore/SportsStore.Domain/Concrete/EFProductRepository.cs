/**
* 命名空间: SportsStore.Domain.Concrete
*
* 功 能： N/A
* 类 名： EFDbContext
* CLR V:  4.0.30319.42000
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/9/22 16:41:12 PC-CAOYUNMING
*/

using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using System.Collections.Generic;
using System;

namespace SportsStore.Domain.Concrete
{
    /// <summary>
    /// Product 仓储库
    /// </summary>
    public class EFProductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();

        /// <summary>
        /// 实现接口定义的属性：获取产品数据
        /// </summary>
        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }

        public void SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int id)
        {
            Product dbEntry = context.Products.Find(id);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
