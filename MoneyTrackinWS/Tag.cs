using System.Xml.Serialization;

namespace MoneyTrackinWS
{
    public class Tag
    {
        [XmlAttribute(AttributeName = "totalAmount")]
        public double TotalAmount { get; set; }

        [XmlElement(ElementName = "valortag")]
        public string Text { get; set; }
    }
}
