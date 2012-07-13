using System.Xml.Serialization;

namespace MoneyTrackinWS
{
    [XmlRoot(ElementName = "result")]
    public class ResultUserData
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlElement(ElementName = "userdata")]
        public UserData Data { get; set; }
    }
}
