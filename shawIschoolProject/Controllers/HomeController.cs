using Microsoft.AspNetCore.Mvc;
using shawIschoolProject.Models;
using shawIschoolProject.Services;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Dynamic;

namespace shawIschoolProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> About() {
            //go get data, put data in model, send result to view  
            DataRetrieval dr = new DataRetrieval();
            var loadedAbout = await dr.GetData("about/");
            var rtnResult = JsonConvert.DeserializeObject<shawIschoolProject.Models.AboutModel>(loadedAbout);

            rtnResult.pageTitle = "About our iSchool";
            return View(rtnResult);


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new shawIschoolProject.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Minors()
        {
            /*
             Go get the data
             put the data in the model
             send the results to the view
             */
            DataRetrieval dr = new DataRetrieval();
            var loadedMinors = await dr.GetData("minors/");
            //We now have a string! need to cast it to JSON

            var minorsReturn = JsonConvert.DeserializeObject<MinorsModel>(loadedMinors);

            dynamic expando = new ExpandoObject();
            var comboModel = expando as IDictionary<string, object>;

            comboModel.Add("Minors", minorsReturn);
            comboModel.Add("pageTitle", "Minors");

            //add in pageTitle
            return View(comboModel);
        }

        public async Task<IActionResult> People() {
            DataRetrieval dataR = new DataRetrieval();
            var loadedPep = await dataR.GetData("people/");
            var jsonResult = JsonConvert.DeserializeObject<PeopleModel>(loadedPep);

            jsonResult.pageTitle = "Our People";

            return View(jsonResult);
        }

        public async Task<IActionResult> Degrees()
        {
            DataRetrieval dataR = new DataRetrieval();
            var loadedPep = await dataR.GetData("degrees/");
            var jsonResult = JsonConvert.DeserializeObject<DegreesModel>(loadedPep);

            jsonResult.pageTitle = "Degrees";

            return View(jsonResult);
        }

        public async Task<IActionResult> Employment()
        {
            DataRetrieval dataR = new DataRetrieval();
            var loadedPep = await dataR.GetData("employment/");
            var jsonResult = JsonConvert.DeserializeObject<EmploymentModel>(loadedPep);

            jsonResult.pageTitle = "Employment";

            return View(jsonResult);
        }

       
    }
}
