using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;

        /// <summary>
        ///构造函数
        /// </summary>
        /// <param name="productsRepository"></param>
        public ProductController(IProductsRepository productsRepository)
        {
            this.repository = productsRepository;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}