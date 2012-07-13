using System;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace MoneyTrackinWS
{
    [DebuggerStepThrough]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "result", Namespace = "", IsNullable = false)]
    [Serializable]
    public class ResultTags
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlElement("tag", Form = XmlSchemaForm.Unqualified)]
        public Tag[] Tags { get; set; }
    }
}
