using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.Common;

namespace Test.Modules.Entities.Controllers
{
    public class TestController : Controller
    {
        [HttpGet(StandardRouting.Partial._TEST_STRUCUTRE)]
        public async Task<IActionResult> ViewTestValueAsync(string testValue)
        {
            Models.CustomModel cm = new Models.CustomModel();
            cm.Line1 = testValue;
            cm.Line2 = StandardRouting.Partial._TEST_STRUCUTRE;
            return View("TestPage", cm);
        }
    }
}
