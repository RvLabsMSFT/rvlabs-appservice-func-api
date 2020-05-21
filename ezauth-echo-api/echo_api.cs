using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ezauth_echo_api
{
    public static class echo_api
    {
        [FunctionName("echo_api")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //log.LogInformation("init");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            UserProfile profile = new UserProfile();
            profile.firstName = data.fn;
            profile.lastName = data.ln;
            profile.email = data.em;
            profile.profilePicUrl = "http://azure-functions";

            return  profile != null
                ? (ActionResult)new OkObjectResult(profile)
                : new BadRequestObjectResult("Please pass some df request body");
        }
    }

    public class UserProfile
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email {get; set; }
        public string profilePicUrl {get; set; }
    }
}
