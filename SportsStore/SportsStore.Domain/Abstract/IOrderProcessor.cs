/**
* 命名空间: SportsStore.Domain.Abstract
*
* 功 能： N/A
* 类 名： IOrderProcessor
* CLR V:  4.0.30319.42000
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/9/22 15:25:06 PC-CAOYUNMING
*/
using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(ShopCart cart, ShippingDetails shippingDetails);
    }
}
