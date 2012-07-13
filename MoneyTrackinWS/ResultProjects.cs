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
    public class ResultProjects
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlElement("project", Form = XmlSchemaForm.Unqualified)]
        public Project[] Items { get; set; }
    }
}
