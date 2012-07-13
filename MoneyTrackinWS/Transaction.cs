using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MoneyTrackinWS
{
    [DebuggerStepThrough]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "transaction", Namespace = "", IsNullable = false)]
    [Serializable]
    public class Transaction
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "amount")]
        public double Amount { get; set; }

        [XmlElement(ElementName = "date")]
        public DateTime Date { get; set; }

        [XmlArray]
        [XmlArrayItem(ElementName = "tag")]
        public string[] tags;
    }
}
