using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NewsReader.Repositories.Models;

namespace NewsReader.Repositories
{
    public class TechMediaRepository : INewsRepository
    {
        private readonly string _xmlFolder;
        private readonly string _xmlArchiveFolder;
        private readonly string _supplier = "TechMedia";

        public TechMediaRepository()
        {
            _xmlFolder = @"C:\News\";
            _xmlArchiveFolder = @"C:\News\Archive";
        }

        public async Task<List<NewsData>> Get()
        {
            var xmlData = ReadFile();
            ArchiveFiles();
            return await TransformToNewsData(xmlData);
        }

        private async Task<List<NewsData>> TransformToNewsData(IEnumerable<NewsStory> xmlData)
        {
            return xmlData.AsParallel().Select(_ => new NewsData()
            {
                AddedDateTime = DateTime.Now,
                ImagePath = _.Imageloc,
                NewsStory = _.Body,
                SupplierName = _supplier,
                Title = _.TopTitle
            }).ToList();
        }

        private List<NewsStory> ReadFile()
        {
            var newsStories = new List<NewsStory>();
            var xmlFiles = Directory.GetFiles(_xmlFolder, "*.xml", SearchOption.TopDirectoryOnly);
            foreach (var xmlFile in xmlFiles)
            {
                var data = File.ReadAllText(xmlFile);
                XmlSerializer xmls = new XmlSerializer(typeof(NewsStory));
                newsStories.Add((NewsStory)xmls.Deserialize(new StringReader(data)));
            }
            return newsStories;
        }

        void ArchiveFiles()
        {
            Archive(_xmlFolder, _xmlArchiveFolder);
        }

        void Archive(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
                File.Delete(file);
            }
        }
    }
}
