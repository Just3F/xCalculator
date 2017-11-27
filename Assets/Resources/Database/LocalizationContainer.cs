using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("LocalizationCollection")]
public class LocalizationContainer{

    [XmlArray("Items")]
    [XmlArrayItem("Item")]
    public List<LocalizationItem> locList = new List<LocalizationItem>();

    public static LocalizationContainer Load()
    {
        TextAsset _xml = Resources.Load<TextAsset>("Database/localization");

        XmlSerializer serializer = new XmlSerializer(typeof(LocalizationContainer));

        StringReader reader  = new StringReader(_xml.text);

        LocalizationContainer items = serializer.Deserialize(reader) as LocalizationContainer;

        reader.Close();

        return items;
    }
}
