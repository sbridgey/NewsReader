using System.Xml.Serialization;

namespace NewsReader.Repositories.Models
{
    [XmlRoot(ElementName = "NewsStory")]
    public class NewsStory
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "topTitle")]
        public string TopTitle { get; set; }
        [XmlElement(ElementName = "body")]
        public string Body { get; set; }
        [XmlElement(ElementName = "imageloc")]
        public string Imageloc { get; set; }
    }
}
