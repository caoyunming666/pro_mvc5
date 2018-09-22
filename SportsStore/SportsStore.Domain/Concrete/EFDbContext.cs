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
using System.Data.Entity;

namespace SportsStore.Domain.Concrete
{
    /// <summary>
    /// 上下文类
    /// </summary>
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
