using System;
using System.Xml.Serialization;

namespace NewsReader.Repositories.Models
{
    [XmlRoot(ElementName = "story")]
    public class Story
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "newstoryText")]
        public string NewstoryText { get; set; }
        [XmlElement(ElementName = "image")]
        public string Image { get; set; }
    }

    [XmlRoot(ElementName = "stories")]
    public class Stories
    {
        [XmlElement(ElementName = "story")]
        public List<Story> Story { get; set; }
    }

    [XmlRoot(ElementName = "publishing")]
    public class Publishing
    {
        [XmlElement(ElementName = "publishingid")]
        public string Publishingid { get; set; }
        [XmlElement(ElementName = "stories")]
        public Stories Stories { get; set; }
    }
}
