using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PushDataVSMVCTutorial.Custom_Responses;
using PushDataVSMVCTutorial.Services;

namespace PushDataVSMVCTutorial.Controllers
{
    public class UserController : ApiController
    {
        //
        // GET: /User/

        private readonly TwitterService _twitterService = new TwitterService();
        private readonly GoogleService _googleService = new GoogleService();
        private readonly GeneralService _generalService = new GeneralService();


        private const string CacheKey = "UserStore";

        /*TODO JMC
         Get user info from twitter
         Authentication
         Get info from google maps
         Build simple html website to display info
         ability to then login and access some values controller*/
        //

        // GET api/user/{userName}
        //LESSON: Should this be a post?
        [System.Web.Mvc.HttpGet]
        public async Task<HttpResponseMessage> Get(string userName)
        {
            var ctx = System.Web.HttpContext.Current;

            //if (ctx != null)
            //{
            //  return (JToken)ctx.Cache[CacheKey];
            //}

            //async await to be completed
            var statuses = await _twitterService.GetUserTimelineData(userName);

            //now google maps
            //for now just workout link
            string mapLoc = null;
            MemoryStream ms = null;
            
            foreach (var status in statuses.Where(status => string.IsNullOrWhiteSpace((string) status["place"])))
            {
                mapLoc = _googleService.SaveMap(Properties.Settings.Default.StaticGoogleMapApi, (string)status["place"]);
                if (string.IsNullOrWhiteSpace(mapLoc)) continue;
                var map = Image.FromFile(mapLoc);
                var mapData = _generalService.ImageToByteArray(map);
                ms = new MemoryStream(mapData);
            }
            
            ctx.Cache[CacheKey] = statuses;

            var response = new HttpResponseMessage(HttpStatusCode.OK);

            if (ms != null)
            {
                response.Content = new StreamContent(ms);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            }
            else
            {
                var apiResponse = new MemoryStream(_generalService.GetBytes(statuses.ToString()));
                response.Content = new StreamContent(apiResponse);
            }

            return response;
        }

    }
}
