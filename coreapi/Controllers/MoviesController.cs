using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace coreapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;

        public MoviesController(ILogger<MoviesController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
            _httpClient = new HttpClient {
                BaseAddress = new Uri(_config["FUNC_ENDPOINT"])
            };

            FUNC_KEY = _config["SUBSCRIPTION_KEY"];
            FUNC_ENDPOINT = _config["FUNC_ENDPOINT"];
        }

        private static string FUNC_ENDPOINT;
        private static string FUNC_KEY;

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

        [HttpGet("/api/func")]
        public async Task<IActionResult> GetCategories()
        {
            _httpClient.DefaultRequestHeaders.Add("x-functions-key", FUNC_KEY);
            HttpResponseMessage response = await _httpClient.GetAsync("api/movies/categories");

            string content = await response.Content.ReadAsStringAsync();

            string responseMessage = string.IsNullOrEmpty(content)
                ? $"********** Request to {FUNC_ENDPOINT} failed ********** "
                : content;

            return new OkObjectResult(responseMessage);
        }
    }
}
