using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using TwitterSample.OAuth;

namespace PushDataVSMVCTutorial.OAuth.Twitter
{
    /// <summary>
    /// Basic DelegatingHandler that creates an OAuth authorization header based on the OAuthBase
    /// class downloaded from http://oauth.net
    /// </summary>
    public class OAuthMessageHandler : DelegatingHandler
    {
        // Obtain these values by creating a Twitter app at http://dev.twitter.com/
        private static readonly string ConsumerKey = Properties.Settings.Default.TwitterConsumerKey;
        private static readonly string ConsumerSecret = Properties.Settings.Default.TwitterConsumerSecret;
        private static readonly string Token = Properties.Settings.Default.TwitterToken;
        private static readonly string TokenSecret = Properties.Settings.Default.TwitterTokenSecret;

        private readonly OAuthBase _oAuthBase = new OAuthBase();

        public OAuthMessageHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Compute OAuth header 
            string normalizedUri;
            string normalizedParameters;
            string authHeader;

            var signature = _oAuthBase.GenerateSignature(
                request.RequestUri,
                ConsumerKey,
                ConsumerSecret,
                Token,
                TokenSecret,
                request.Method.Method,
                _oAuthBase.GenerateTimeStamp(),
                _oAuthBase.GenerateNonce(),
                out normalizedUri,
                out normalizedParameters,
                out authHeader);

            request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authHeader);
            return base.SendAsync(request, cancellationToken);
        }
    }
}