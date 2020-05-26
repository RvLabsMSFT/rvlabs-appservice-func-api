using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace coreapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        
        private static string FUNC_ENDPOINT;
        private static string FUNC_KEY;
        private static string _token;

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

        public async Task GetAccessToken()
        {
            IConfidentialClientApplication _app;
            _app = ConfidentialClientApplicationBuilder.Create(_config["ClientId"])
                    .WithClientSecret(_config["ClientSecret"])
                    .WithAuthority(new Uri(_config["Authority"]))
                    .Build();
            
            string[] scopes = new string[] { _config["Scope"] };

            AuthenticationResult result = null;
            result = await _app.AcquireTokenForClient(scopes)
                  .ExecuteAsync();

            _token = result.AccessToken;
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

        [HttpGet("/api/func")]
        public async Task<IActionResult> GetCategories()
        {
            await GetAccessToken();

            _httpClient.DefaultRequestHeaders.Add("x-functions-key", FUNC_KEY);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            HttpResponseMessage response = await _httpClient.GetAsync("api/movies/categories");

            string content = await response.Content.ReadAsStringAsync();

            ReplyObject reply = new ReplyObject();

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            string message = string.IsNullOrEmpty(content)
                ? $"********** Request to {FUNC_ENDPOINT} failed ********** "
                : content;
            
            reply.token = _token;
            reply.categories = message;
            _logger.LogInformation($"####### {message}");
            return new OkObjectResult(JsonSerializer.Serialize(reply, options));
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

    public class ReplyObject
    {
        public string token { get; set; }
        public string categories { get; set; }
    }
}
