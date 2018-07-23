using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LoLCrawler
{
    class RequestMaker
    {
        private async Task<string> makeRequest(string url)
        {
            HttpClient client = new HttpClient();
            string result;

            // Call asynchronous network methods in a try/catch block to handle exceptions
            try
            {
                result = await client.GetStringAsync(url);

            }
            catch (HttpRequestException e)
            {
                result = e.Message;
            }

            // Need to call dispose on the HttpClient object
            // when done using it, so the app doesn't leak resources
            client.Dispose();
            return result;
        }

        public string Fetch(string url)
        {
            return makeRequest(url).Result;
        }
    }
}
