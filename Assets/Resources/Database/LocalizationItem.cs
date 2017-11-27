using System.Xml.Serialization;

public class LocalizationItem
{
    [XmlAttribute("wordIdentifire")]
    public string wordIdentifire { get; set; }

    [XmlElement("RU")]
    public string RU { get; set; }

    [XmlElement("EU")]
    public string EU { get; set; }

}
