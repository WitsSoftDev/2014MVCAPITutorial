using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PushDataVSMVCTutorial.Services;

namespace PushDataVSMVCTutorial.Controllers
{
    public class UserController : ApiController
    {
        //
        // GET: /User/

        private readonly TwitterService _twitterService = new TwitterService();
        private readonly GoogleService _googleService = new GoogleService();
        

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
        public async Task<JToken> Get(string userName)
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

            if (statuses.Children()["place"].Values() != null)
            {
                throw new NotImplementedException();
            }

            /*foreach (var status in statuses)
            {
                Console.WriteLine("   {0}", status["text"]);
                Console.WriteLine();
            }*/

            ctx.Cache[CacheKey] = statuses;

            /*todo add responses*/

            return statuses;
        }

    }
}
