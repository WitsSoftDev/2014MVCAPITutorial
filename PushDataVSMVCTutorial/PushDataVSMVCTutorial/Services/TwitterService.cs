using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using PushDataVSMVCTutorial.Custom_Responses;
using PushDataVSMVCTutorial.Models.API;
using PushDataVSMVCTutorial.OAuth.Twitter;

namespace PushDataVSMVCTutorial.Services
{
    
    public class TwitterService : ITwitterService
    {
        private const string CacheKey = "TweetStore";

        /*TODO JMC Check result works*/
        public async Task<JToken> GetUserTimelineData(string userName)
        {
            var client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));

            var address = Properties.Settings.Default.TwitterGetUserTimeline + userName;

            // Send asynchronous request to twitter and read the response as JToken
            var response = await client.GetAsync(address);

            //should handle missing userName
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpResponseException(response);
            }

            var twitterUserStatuses = await response.Content.ReadAsAsync<JToken>();
            return twitterUserStatuses;
        }


    }
}