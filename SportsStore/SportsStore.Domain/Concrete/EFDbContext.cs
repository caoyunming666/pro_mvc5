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
    /// EF ORM框架的上下文类：属性对应表明
    ///     处理模型与数据库关联起来
    ///     注意：如何告诉 EF 如何连接到数据库，需要在网站的配置文件中添加一条数据库连接字符串，该字符串的
    ///     名称与这个上下文类的名称相同。
    /// </summary>
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
