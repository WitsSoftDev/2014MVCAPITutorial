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
using PushDataVSMVCTutorial.Custom_Responses.Exceptions;
using PushDataVSMVCTutorial.Services;

namespace PushDataVSMVCTutorial.Controllers
{
    public class UserController : ApiController
    {
        //
        // GET: /User/

        private readonly ITwitterService _twitterService = new TwitterService();
        private readonly GoogleService _googleService = new GoogleService();
        private readonly IGeneralService _generalService = new GeneralService();


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
            //async await to be completed
            var statuses = await _twitterService.GetUserTimelineData(userName);

            //now google maps
            //for now just workout link
            MemoryStream ms = null;

            HttpResponseMessage response;

            foreach (var status in statuses)
            {
                var mapLoc = userName + ".png";

                if (!string.IsNullOrWhiteSpace((string) status["place"]))
                {
                    await _googleService.SaveMap(Properties.Settings.Default.StaticGoogleMapApi, userName);
                }
                else
                {
                    await _googleService.SaveMap(userName);
                }
                
                var map = Image.FromFile(mapLoc);
                var mapData = _generalService.ImageToByteArray(map);
                ms = new MemoryStream(mapData);
            }
            
            //save user to 'database' just an xml file
            if (ms != null)
            {
                response = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StreamContent(ms)};
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                var apiResponse = new MemoryStream(_generalService.GetBytes(statuses.ToString()));
                response.Content = new StreamContent(apiResponse);

                return response;
            }
            var message = _generalService.GetBytes("The Map file was not found");
            ms = new MemoryStream(message);
            response = new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StreamContent(ms) };
            
            return response;
        }
    }
}
