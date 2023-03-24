using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
//using MonitoringWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using MvcMovie.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MvcMovie.Controllers{

    public class JokeController : Controller
    {
        // 
        // GET: Joke/Welcome
        public async Task<IActionResult> Welcome(string ID)
        {
            //int ID = 1;
            //string[] choices = {"0", "Random"};
            string BaseUrl = "https://official-joke-api.appspot.com/";
            List<Joke> sample = new List<Joke>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Add(/*API KEY*/);
                
                    string URI = $"jokes/{ID}";
                    HttpResponseMessage response = await client.GetAsync(URI);
                    if (response.IsSuccessStatusCode)
                    {
                        var jokeResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<Joke>(jokeResponse);
                        sample.Add(result);
                        ViewData["collects"] = sample;
                    }  
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Input(string myText)
        {
            //int ID = myText;
            int ID;
            if (int.TryParse(myText, out ID))
            {
                //ViewData["collects"] = new List<Joke>();
                return await Welcome(myText);
            }
            else
            {
                return RedirectToAction("Welcome", new { ID = 1 });
            }
        }
    }
}

        /*/ GET: WeatherController/Create
        public ActionResult Create(int id)
        {
            //ViewData["id"] = id;
            return View();
        }

        // GET: WeatherController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeatherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeatherController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeatherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: /HelloWorld/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        [HttpPost]
        public string Index(string searchString, bool notUsed){

            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}*/
