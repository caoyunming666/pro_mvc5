/**
* 命名空间: SportsStore.Domain.Entities
*
* 功 能： N/A
* 类 名： Products
* CLR V:  4.0.30319.42000
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/9/22 15:21:39 PC-CAOYUNMING
*/
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SportsStore.Domain.Entities
{
    public class Product
    {
        /// <summary>
        /// 告诉mvc框架：将id属性渲染为隐藏的表单元素
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// datatype注解：指示我们如何编辑一个值
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
