using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThAmCo.Venues.Data;

namespace ThAmCo.Events.Controllers
{
    public class ReservationsController : Controller
    {
        // Creating the Http Client
        HttpClient client;

        public ReservationsController()
        {
            // Setting up the Http Client
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://localhost:44352/");
            client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
        }
        // GET: EventTypesController
        public async Task<ActionResult> Index()
        {
            IEnumerable<ReservationDto> reservations = new List<ReservationDto>();

            // Calling the api
            HttpResponseMessage response = await client.GetAsync("api/Reservations");
            if (response.IsSuccessStatusCode)
            {
                reservations = await response.Content.ReadAsAsync<IEnumerable<ReservationDto>>();
            }
            else
            {
                Debug.WriteLine("Index received a bad response from the web service.");
            }
            return View(reservations.ToList());
        }

        // GET: EventTypesController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            ReservationDto reservations = new ReservationDto();

            // Calling the api
            HttpResponseMessage response = await client.GetAsync("api/Reservations/" + id);
            if (response.IsSuccessStatusCode)
            {
                reservations = await response.Content.ReadAsAsync<ReservationDto>();
            }
            else
            {
                Debug.WriteLine("Details received a bad response from the web service.");
                return NotFound();
            }
            return View(reservations);
        }

        // GET: EventTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservationDto reservations)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Reservations", reservations);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Debug.WriteLine("Create received a bad response from the web service.");
            }
            return View(reservations);
        }

        // GET: EventTypesController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            ReservationDto reservations = new ReservationDto();

            HttpResponseMessage response = await client.GetAsync("api/Reservations/" + id);
            if (response.IsSuccessStatusCode)
            {
                reservations = await response.Content.ReadAsAsync<ReservationDto>();
            }
            else
            {
                Debug.WriteLine("Edit received a bad response from the web service.");
                return NotFound();
            }
            return View(reservations);
        }

        // POST: EventTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, ReservationDto reservations)
        {
            if (!id.Equals(reservations.Reference))
            {
                return NotFound();
            }

            HttpResponseMessage response = await client.PutAsJsonAsync("api/Reservations/" + id, reservations);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Debug.WriteLine("Edit received a bad response from the web service.");
            }
            return View(reservations);
        }

        // GET: EventTypesController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            ReservationDto reservations = new ReservationDto();

            HttpResponseMessage response = await client.GetAsync("api/Reservations/" + id);
            if (response.IsSuccessStatusCode)
            {
                reservations = await response.Content.ReadAsAsync<ReservationDto>();
            }
            else
            {
                Debug.WriteLine("Delete received a bad response from the web service.");
                return NotFound();
            }
            return View(reservations);
        }

        // POST: EventTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync("api/Reservations/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Debug.WriteLine("Delete received a bad response from the web service.");
                return BadRequest();
            }
        }
    }
}
