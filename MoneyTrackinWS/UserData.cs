using System.Xml.Serialization;

namespace MoneyTrackinWS
{
    public class UserData
    {
        //<result code="done">
        //  <userdata user="username">
        //    <email>user@email.com</email>
        //    <currency>EUR</currency>
        //    <locale>es_ES</locale>
        //    <htmlchar>€</htmlchar>
        //    <dateformat>dd/mm/yyyy</dateformat>
        //    <mainaccountname>Main Account</mainaccountname>
        //  </userdata>
        //</result>
        [XmlAttribute(AttributeName = "user")]
        public string UserName { get; set; }
        [XmlElement(ElementName = "email")]
        public string Email { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "locale")]
        public string Locale { get; set; }
        [XmlElement(ElementName = "htmlchar")]
        public string HtmlChar { get; set; }
        [XmlElement(ElementName = "dateformat")]
        public string DateFormat { get; set; }
        [XmlElement(ElementName = "mainaccountname")]
        public string MainAccountName { get; set; }
    }
}
