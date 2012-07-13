using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MoneyTrackinWS
{
    [DebuggerStepThrough]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "project", Namespace = "", IsNullable = false)]
    [Serializable]
    public class Project
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "balance")]
        public double Balance { get; set; }
        [XmlElement(ElementName = "htmlchar")]
        public string HtmlChar { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "balancem")]
        public double BalanceCurrency { get; set; }
    }
}
