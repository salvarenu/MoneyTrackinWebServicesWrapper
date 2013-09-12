using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace MoneyTrackinWS
{
    [DebuggerStepThrough]
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "transaction", Namespace = "", IsNullable = false)]
    [Serializable]
    public class Transaction : IComparable<Transaction>
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

        public int projectId { get; set; }
        public string projectName { get; set; }

        public string TagList
        {
            get
            {
                string list = String.Empty;
                foreach (string s in tags)
                {
                    list += s + " ";
                }
                return list;
            }
        }

        public string DateAsString
        {
            get
            {
                return Date.ToShortDateString();
            }
        }

        public int CompareTo(Transaction other)
        {
            return Date.CompareTo(other.Date);
        }

    }
}
