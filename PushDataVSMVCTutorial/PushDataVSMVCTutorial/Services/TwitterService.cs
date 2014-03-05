using System.Web;
using PushDataVSMVCTutorial.Models.API;

namespace PushDataVSMVCTutorial.Services
{
    
    public class TwitterService
    {
        private const string CacheKey = "TweetStore";

        public TwitterService()
        {
            /*to add static test data*/
            /*var ctx = HttpContext.Current;

            if (ctx == null) return;
            if (ctx.Cache[CacheKey] != null) return;
            var tweets = new Tweets[]
            {
                new Tweets
                {
                    Id = 1, Name = "Glenn Block"
                },
                new Tweets
                {
                    Id = 2, Name = "Dan Roth"
                }
            };

            ctx.Cache[CacheKey] = tweets;*/
        }


    }
}