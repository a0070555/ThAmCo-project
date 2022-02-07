using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThAmCo.Venues.Data;

namespace ThAmCo.Events.Controllers
{
    public class AvailabilityController : Controller
    {
        // Creating a new Http client
        HttpClient client;

        public AvailabilityController()
        {
            // Setting up the http client
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44352/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }
        // GET: AvailabilityController
        public async Task<ActionResult> Index()
        {
            // Creating the model
            IEnumerable<AvailabilityDto> availability = new List<AvailabilityDto>();

            // Calling the api
            HttpResponseMessage response = await client.GetAsync("api/Availability");
            if (response.IsSuccessStatusCode)
            {
                availability = await response.Content.ReadAsAsync<IEnumerable<AvailabilityDto>>();
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }
            return View(availability.ToList());
        }

        // GET: AvailabilityController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            // Creating the model
            AvailabilityDto availability = new AvailabilityDto();

            // Calling the api
            HttpResponseMessage response = await client.GetAsync("api/Availability/" + id);
            if (response.IsSuccessStatusCode)
            {
                availability = await response.Content.ReadAsAsync<AvailabilityDto>();
            }
            else
            {
                Debug.WriteLine("Details received a bad response from the web service.");
                return NotFound();
            }
            return View(availability);
        }
    }
}
