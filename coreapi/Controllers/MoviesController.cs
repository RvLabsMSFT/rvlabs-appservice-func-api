using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace coreapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        public List<MovieItem> ReadMoviesDataSet()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var jsonString = System.IO.File.ReadAllText("movies-dataset.json");
            var jsonModel = JsonSerializer.Deserialize<List<MovieItem>>(jsonString, options);
            
            _logger.LogInformation($"Read dataset with {jsonModel.Count} items");

            return jsonModel;
        }

        [HttpGet("/api/test")]
        public IActionResult test()
        {
            var data = ReadMoviesDataSet();

            return new OkObjectResult(data[0]);
        }

        [HttpGet("/api/movies/top10")]
        public IActionResult GetTopTen()
        {
            var data = ReadMoviesDataSet();

            return new OkObjectResult(data.GetRange(0, 10));
        }

        [HttpGet("/api/movies/all")]
        public IActionResult GetMovies()
        {
            var data = ReadMoviesDataSet();

            return new OkObjectResult(data);
        }
    }
}
