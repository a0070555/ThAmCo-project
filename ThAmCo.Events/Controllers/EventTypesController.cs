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
    public class EventTypesController : Controller
    {
        // Creating the Http Client
        HttpClient client;

        public EventTypesController()
        {
            // Setting up the Http Client
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44352/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }
        // GET: EventTypesController
        public async Task<ActionResult> Index()
        {
            IEnumerable<EventTypeDto> eventType = new List<EventTypeDto>();

            // Calling the api
            HttpResponseMessage response = await client.GetAsync("api/EventTypes");
            if (response.IsSuccessStatusCode)
            {
                eventType = await response.Content.ReadAsAsync<IEnumerable<EventTypeDto>>();
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }
            return View(eventType.ToList());
        }

        // GET: EventTypesController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            EventTypeDto eventType = new EventTypeDto();

            // Calling the api
            HttpResponseMessage response = await client.GetAsync("api/EventTypes/" + id);
            if (response.IsSuccessStatusCode)
            {
                eventType = await response.Content.ReadAsAsync<EventTypeDto>();
            }
            else
            {
                Debug.WriteLine("Details received a bad response from the web service.");
                return NotFound();
            }
            return View(eventType);
        }
    }
}
