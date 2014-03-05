using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PushDataVSMVCTutorial.OAuth.Twitter;
using PushDataVSMVCTutorial.Services;

namespace PushDataVSMVCTutorial.Controllers
{
    public class UserController : ApiController
    {
        private readonly TwitterService _twitterService;
        private const string CacheKey = "TweetStore";

        /*TODO JMC
         Get user info from twitter
         Authentication
         Get info from google maps
         Build simple html website to display info
         ability to then login and access some values controller*/
        //
        // GET: /User/

        //LESSON: Should this be a post?
        [System.Web.Mvc.HttpGet]
        //[Route("~/api/Twitter/GetLiveData")]
        public async Task<JToken> Get()
        {
            var ctx = HttpContext.Current;

            //if (ctx != null)
            //{
            //  return (JToken)ctx.Cache[CacheKey];
            //}

            var client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));

            // Send asynchronous request to twitter and read the response as JToken
            var response = await client.GetAsync(Properties.Settings.Default.TwitterSearchCriteria);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseException(response);
            }

            var tweets = await response.Content.ReadAsAsync<JToken>();

            //now will have to get coordinates since Twitter Api does not support 
            //var result = JsonConvert.DeserializeObject<Tweets>(tweets.ToString());
            //var tweetIds = tweets["id"].Value<JObject>();
            //var ids = tweetIds.Properties().Select(p => p.Name).ToList();
            //var stringOfTweets = JsonConvert.DeserializeObject<Tweets>(tweets.ToString());
            //var dataTableOfTweets = stringOfTweets.Ids;
            //var array = JArray.Parse(tweets.ToString());
            JToken tweetList = tweets["statuses"].Values<JToken>();
            var ids = tweetList["id"].Value<string>();
            foreach (var i in ids)
            {
                //foreach (var prop in tweet.Properties())
                //{
                //    response = await client.GetAsync((Properties.Settings.Default.TwitterTweetCoordinates + prop.id));
                //    if (response.IsSuccessStatusCode)
                //    {

                //    }
                //}

                //var id = JsonConvert.DeserializeObject<Tweets>(i.ToString());
                //Console.WriteLine(id);
            }
            /*string test = "";
            var o = JObject.Parse(tweets.ToString());

            foreach (var child in o.Children())
            {
                foreach (var grandChild in child)
                {
                    //foreach (var grandGrandChild in grandChild)
                    //{
                        var property = grandChild as JProperty;

                        if (property != null)
                        {
                            //Console.WriteLine(property.Name + ":" + property.Value);
                            test += property.Name + ":" + property.Value + "\n";
                        }
                    //}
                }
            }

            test=test;*/

            if (ctx != null)
                ctx.Cache[CacheKey] = tweets;


            return tweets;
        }
    }
}
