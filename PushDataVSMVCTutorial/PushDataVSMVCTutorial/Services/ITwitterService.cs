using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PushDataVSMVCTutorial.Services
{
    public interface ITwitterService
    {
        Task<JToken> GetUserTimelineData(string userName);
    }
}