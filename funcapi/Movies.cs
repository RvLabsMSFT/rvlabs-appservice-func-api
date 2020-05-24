using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;

namespace funcapi
{
    public static class Movies
    {
        [FunctionName("Movies")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "movies/categories")] HttpRequest req,
            ILogger log)
        {
            var categoryList = JsonConvert.SerializeObject(Categories);

            return new OkObjectResult(categoryList);
        }

        public static readonly string[] Categories = new[]
        {
            "Action", "Adventure", "Animated", "Biography", "Comedy",
            "Crime", "Documentary", "Drama", "Horror", "Independent",
            "Martial Arts", "Musical", "Mystery", "Romance", "Satire", 
            "Science Fiction", "Short", "Silent", "Slasher", 
            "Suspense", "Teen", "Thriller", "War", "Western"
        };
    }
}
