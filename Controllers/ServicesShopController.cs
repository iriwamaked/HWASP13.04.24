using HWASP.Data.DAL;
using Microsoft.AspNetCore.Mvc;

namespace HWASP.Controllers
{
    public class ServicesShopController (DataAccessor dataAccessor) : Controller
    {
        private readonly DataAccessor _dataAccessor = dataAccessor;
        public IActionResult Index()
        {
            //передаем категории на представление
            ViewData["Categories"] = _dataAccessor.ServicesShopDao.GetCategories();
            return View();
        }
    }
}
