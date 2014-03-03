using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PushDataVSMVCTutorial.OAuth.Twitter;
using WSDAPILibrary;
using PushDataVSMVCTutorial.Models.API;


namespace PushDataVSMVCTutorial.Controllers
{
    public class TwitterController : ApiController
    {
        //
        // GET: /api/Twitter/

        [System.Web.Mvc.HttpGet]
        //[RoutePrefix()]
        public async Task<JToken> GetLiveData()
        {
            var tweets = new List<Tweets>();
            var client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));

            // Send asynchronous request to twitter and read the response as JToken
            var response = await client.GetAsync(Properties.Settings.Default.TwitterSearchCriteria);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseException(response);
            }

            var statuses = await response.Content.ReadAsAsync<JToken>();
            //Console.WriteLine("Most recent statuses from Keduce22's twitter account:");
            var result = new { tweets = statuses };
            //foreach (var status in statuses)
            //{
            //Console.WriteLine("   {0}", status["text"]);
            //Console.WriteLine();
            //result = new { "Most recent statuses from Keduce22's twitter account:" };
            //}
            //return HttpResponses.Ok();
            return statuses;
        }

        //
        // GET: /Twitter/Details/5

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
            //return View();
        }

        //
        // GET: /Twitter/Create

        public ActionResult Create()
        {
            throw new NotImplementedException();
            //return View();
        }

        //
        // POST: /Twitter/Create

        [System.Web.Mvc.HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            throw new NotImplementedException();
            /*try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }*/
        }

        //
        // GET: /Twitter/Edit/5

        public ActionResult Edit(int id)
        {
            throw new NotImplementedException();
            //return View();
        }

        //
        // POST: /Twitter/Edit/5

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            throw new NotImplementedException();
            /*try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }*/
        }

        //
        // GET: /Twitter/Delete/5

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
            //return View();
        }

        //
        // POST: /Twitter/Delete/5

        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            throw new NotImplementedException();
            /*try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }*/
        }
    }
}
