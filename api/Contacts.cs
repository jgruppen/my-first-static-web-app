using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using api.Services;
using System.Collections.Generic;
using api.Domain;

namespace StaticWebApp.Api
{
    public class Contacts
    {
        private readonly IContactService _contactService;

        public Contacts(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }

        [FunctionName("Contacts")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                List<Contact> contacts = await _contactService.GetAllContactsAsync();

                return new OkObjectResult(contacts);
            }
            catch(Exception ex)
            {
                log.LogError(ex, "Failed to get contacts");

                return new OkObjectResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
