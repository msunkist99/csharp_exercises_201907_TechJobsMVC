using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        internal static IEnumerable<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
        internal static string holdSearchType;
        internal static string holdSearchTerm;

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.jobs = jobs;
            ViewBag.searchType = holdSearchType;
            ViewBag.searchTerm = holdSearchTerm;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType == "all")
            {
                jobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            IEnumerable<string> values = new List<string>();
            holdSearchType = searchType;
            holdSearchTerm = searchTerm;

            return RedirectToAction("Index", values);
            //return View();
        }

        // TODO #1 - DONE - Create a Results action method to process 
        // search request and display results

    }
}
