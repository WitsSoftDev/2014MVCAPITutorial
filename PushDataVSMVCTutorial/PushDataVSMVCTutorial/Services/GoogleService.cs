using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PushDataVSMVCTutorial.Services
{
    public class GoogleService
    {
        /*TODO tutorial add options for map, not hard coded*/
        /*TODO JMC add interfaces*/
        
        public string SaveMap(string address, string location)
        {
            address += ",WA&zoom=14&size=500x500&sensor=false";
            var map = GetStaticMapImage(address, location);
            return location + ".png";
        }
        private static async Task GetStaticMapImage(string address, string location)
        {
            var client = new HttpClient();

            // Send asynchronous request
            var response = await client.GetAsync(address);

            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();

            // Read response asynchronously and save asynchronously to file
            using (var fileStream = new FileStream(location+".png", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await response.Content.CopyToAsync(fileStream);
            }
        }
    }
}