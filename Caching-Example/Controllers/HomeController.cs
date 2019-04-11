using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Caching_Example.Models;
using Microsoft.Extensions.Caching.Memory;
using Caching;
using Caching.Models;

namespace Caching.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache _memoryCache;
        public class CacheValueAndsource
        {
            public string EmployeeName { get; set; }
            public string Source { get; set; }
        }


        public CacheValueAndsource CacheFirstWay()
        {
            string cacheValue;
            string sourceOfData = "Cache";
            CacheValueAndsource cvs = new CacheValueAndsource();
            cvs.EmployeeName = null;
            cvs.Source = null;
            // Look for cache key.
            if (!_memoryCache.TryGetValue<string>("_EmployeeName", out cacheValue))
            {
                // Key not in cache, so get data.
                EmployeeViewModel model = new EmployeeViewModel(1,2,"engineer", "malek");
                cacheValue = model.emp.fullName;
                sourceOfData = "Not Cache";

                //Cache expiration
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));

                // Save values in cache for a given key.
                _memoryCache.Set<string>("_EmployeeName", cacheValue, cacheEntryOptions);
            }
            cvs.EmployeeName = cacheValue.ToString();
            cvs.Source = sourceOfData.ToString();
            return cvs;
        }

        public string EmployeeDetails()
        {
            var value = _memoryCache.Get<string>("_EmployeeName");

            string cacheValue;
            if (!_memoryCache.TryGetValue<string>("_EmployeeName", out cacheValue))
            {
                value= "the cache is empty , so the app will fill it with the name Jhon , reload the page to see that !";
            }

            _memoryCache.GetOrCreate<string>("_EmployeeName",
                  cacheEntry => {
                      return "John";
                  });
            return value;
        }


        public HomeController(IMemoryCache memoryCache)
        {
            this._memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            CacheValueAndsource vv = CacheFirstWay();
            ViewData["name"] = vv.EmployeeName;
            ViewData["source"] = vv.Source;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = EmployeeDetails();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
