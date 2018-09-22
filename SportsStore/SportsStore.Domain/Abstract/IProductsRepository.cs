

using SportsStore.Domain.Entities;
/**
* 命名空间: SportsStore.Domain.Abstract
*
* 功 能： N/A
* 类 名： IProductsRepository
* CLR V:  4.0.30319.42000
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/9/22 15:25:06 PC-CAOYUNMING
*/
using System.Collections.Generic;

namespace SportsStore.Domain.Abstract
{
    /// <summary>
    /// 产品接口：提供获取产品集合方法(只提供方法，在派生类中实现具体细节)
    /// </summary>
    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
