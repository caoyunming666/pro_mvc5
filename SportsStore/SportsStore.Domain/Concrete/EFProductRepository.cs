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

        public IEnumerable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }
    }
}
