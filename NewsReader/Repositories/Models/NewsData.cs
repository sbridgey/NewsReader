using System;
namespace NewsReader.Repositories.Models
{
    public class NewsData
    {
        public int NewsStoryID { get; set; }
        public string Title { get; set; }
        public string NewsStory { get; set; }
        public string ImagePath { get; set; }
        public string SupplierStoryRef { get; set; }
        public DateTime AddedDateTime { get; set; }
        public string SupplierName { get; set; }
    }
}
