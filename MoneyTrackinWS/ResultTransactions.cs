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
    public class ResultTransactions
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        [XmlElement("transaction", Form = XmlSchemaForm.Unqualified)]
        public Transaction[] Items { get; set; }
    }
}
