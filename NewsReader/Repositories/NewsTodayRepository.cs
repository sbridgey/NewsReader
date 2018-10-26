using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NewsReader.Repositories.Models;

namespace NewsReader.Repositories
{
    public class NewsTodayRepository : INewsRepository
    {
        private HttpClient _httpClient;

        public NewsTodayRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://www.example.com/");
            _httpClient.DefaultRequestHeaders.Accept
                       .Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        }



        public void Get()
        {
            throw new NotImplementedException();
        }

        private async Task<Publishing> GetData()
        {
            var data = new Publishing();
            HttpResponseMessage resp = _httpClient.GetAsync("xml").Result;

            if (resp.IsSuccessStatusCode)
            {
                XmlSerializer xmls = new XmlSerializer(typeof(Publishing));
                var responseString = await resp.Content.ReadAsStringAsync();
                data = (Publishing)xmls.Deserialize(new StringReader(responseString));
                // Parse the response body. 
            }

            return data;
        }

        private NewsData TransformToNewsData(Story story)
        {
            throw new NotImplementedException();
        }
    }
}
