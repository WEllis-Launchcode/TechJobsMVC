using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        [HttpGet]
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType.Equals("all"))
            {
                List<Dictionary<string, string>> searchResults = JobData.FindByValue(searchTerm);
                ViewBag.jobs = searchResults;
            }
            else
            {
                List<Dictionary<string, string>> searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = searchResults;
            }
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search by " + ListController.columnChoices[searchType] + ": " + searchTerm;
            return View("Index");
        } 
    }
}
