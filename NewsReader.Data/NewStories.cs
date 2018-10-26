using System;

namespace NewsReader.Data
{
    public class NewStories
    {
        public int NewsStoryID { get; set; }
        public string Title { get; set; }
        public string NewsStory { get; set; }
        public string ImagePath { get; set; }
        public string SupplierStoryRef { get; set; }
        public DateTime AddedDateTime {get; set;}

        public int SupplierID { get; set; }
        public Suppliers Supplier { get; set; }
    }
}