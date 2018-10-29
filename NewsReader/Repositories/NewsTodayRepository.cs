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
        private string _supplier = "NewsToday";

        public NewsTodayRepository()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://www.example.com/");
            _httpClient.DefaultRequestHeaders.Accept
                       .Add(new MediaTypeWithQualityHeaderValue("application/xml"));
        }

        public async Task<List<NewsData>> Get()
        {
            var rawData = await GetData().ConfigureAwait(false);
            return TransformToNewsData(rawData);
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
            }

            return data;
        }

        private List<NewsData> TransformToNewsData(Publishing publishings)
        {
            var data = new List<NewsData>();
            foreach(var story in publishings.Stories.Story)
            {
                data.Add(new NewsData()
                {
                    AddedDateTime = DateTime.Now,
                    ImagePath = story.Image,
                    NewsStory = story.NewstoryText,
                    SupplierName = _supplier,
                    Title = story.Title
                });
            }

            return data;
        }
    }
}
