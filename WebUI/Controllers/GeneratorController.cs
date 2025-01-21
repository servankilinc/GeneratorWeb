using Microsoft.AspNetCore.Mvc;
using WebUI.DynamicScaffolding;
using WebUI.Repository;

namespace WebUI.Controllers
{
    public class GeneratorController : Controller
    {
        private readonly EntityRepository _entityRepository;
        public GeneratorController(EntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public IActionResult Index()
        {
            var DynamicScaffolding = new DynamicScaffolding.DynamicScaffolding(_entityRepository);
            string solutionPath = @"C:\Users\serva\OneDrive\Masaüstü\Generator\GeneratorWeb";// C:\Users\serva\OneDrive\Masaüstü\Generator\GeneratorWeb\GeneratorWeb.sln
            string templateFolderPath = @"C:\Users\serva\OneDrive\Masaüstü\Generator\GeneratorWeb\WebUI\Schema";

            DynamicScaffolding.GenerateCode(solutionPath, templateFolderPath);
            return View();
        }
    }
}
