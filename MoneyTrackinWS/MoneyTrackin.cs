using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MoneyTrackinWS
{
    public class MoneyTrackin
    {
        private string _user;
        private string _password;
        private string _encodedPassword;

        public MoneyTrackin(string user, string password)
        {
            _user = user;
            _password = password;
        }

        public UserData GetUserData()
        {
            RESTClient clientWs = new RESTClient();
            string xmlData = clientWs.MakeRequest("userData", _user, _password);
            XmlSerializer serialize = new XmlSerializer(typeof(ResultUserData));
            ResultUserData result = (ResultUserData)serialize.Deserialize(new StringReader(xmlData));
            return result.Data;
        }

        public List<Project> GetProjects()
        {
            //<?xml version='1.0' encoding='UTF-8'?>
            //<result code="done">
            //  <project id="">
            //    <name>Main Account</name>
            //    <balance>3455.14</balance>
            //    <htmlchar>€</htmlchar>
            //    <currency>EUR</currency>
            //    <balancem>3455.14</balancem>
            //  </project>
            //  <project id="4">
            //    <name>test project 1</name>
            //    <balance>-48.77</balance>     
            //    <htmlchar>$</htmlchar>
            //    <balancem>-61.73</balancem>
            //  </project>
            //  <project id="5">
            //    <name>test project 2</name>
            //    <balancem>1021.73</balancem>
            //    <htmlchar>€</htmlchar>
            //    <balancem>1021.73</balancem>
            //    <perm>1</perm>
            //  </project>
            //</result>

            //name     - Project name
            //balance  - Project balance
            //htmlchar - The symbol for the project currency
            //currency - The project currency
            //balancem - Project balance converted to the user default currency
            //perm     - Project's permission (shared projects only). 0->read only  1-> read/write

            RESTClient clientWs = new RESTClient();
            string xmlData = clientWs.MakeRequest("listProjects", _user, _password);
            XmlSerializer serialize = new XmlSerializer(typeof(ResultProjects));
            ResultProjects result = (ResultProjects)serialize.Deserialize(new StringReader(xmlData));
            return new List<Project>(result.Items);

        }

        public List<Transaction> GetTransactions(int? projectId, DateTime startDate, DateTime endDate)
        {
            //<?xml version='1.0' encoding='UTF-8'?>
            //<result code="done">
            //  <transaction id="13">
            //    <description>mortgage</description>
            //    <amount>-400</amount>
            //    <date>2006-05-24</date>
            //    <tags>
            //      <tag>mortgage</tag>
            //      <tag>mensual</tag>
            //    </tags>
            //  </transaction>
            //  <transaction id="12">
            //    <description>salary</description>
            //    <amount>1520</amount>
            //    <date>2006-05-24</date>
            //    <tags>
            //      <tag>salary</tag>
            //      <tag>job</tag>
            //    </tags>
            //  </transaction>
            //</result>
            RESTClient clientWs = new RESTClient();
            string strProjectId = projectId.HasValue ? projectId.Value.ToString() : String.Empty;
            string strStartDate = startDate.ToString("yyyy-MM-dd");
            string strEndDate = endDate.ToString("yyyy-MM-dd");
            string xmlData = clientWs.MakeRequest("listTransactions?project=" + strProjectId + "&startDate=" + strStartDate + "&endDate=" + strEndDate, _user, _password);
            XmlSerializer serialize = new XmlSerializer(typeof(ResultTransactions));
            ResultTransactions result = (ResultTransactions)serialize.Deserialize(new StringReader(xmlData));
            return new List<Transaction>(result.Items);
        }

        public List<Transaction> GetTagTransactions(int? projectId, DateTime startDate, DateTime endDate, string tag)
        {
            RESTClient clientWs = new RESTClient();
            string strProjectId = projectId.HasValue ? projectId.Value.ToString() : String.Empty;
            string strStartDate = startDate.ToString("yyyy-MM-dd");
            string strEndDate = endDate.ToString("yyyy-MM-dd");
            string xmlData = clientWs.MakeRequest("listTagTransactions?project=" + strProjectId + "&startDate=" + strStartDate + "&endDate=" + strEndDate + "&tag= " + tag, _user, _password);
            XmlSerializer serialize = new XmlSerializer(typeof(ResultTransactions));
            ResultTransactions result = (ResultTransactions)serialize.Deserialize(new StringReader(xmlData));
            return new List<Transaction>(result.Items);
        }

        public List<Tag> GetTags(int? projectId)
        {
            //<?xml version='1.0' encoding='UTF-8'?>
            //<result code="done">
            //    <tag totalAmount="-300.25">
            //        <valortag>car</valortag>
            //    </tag>
            //    <tag totalAmount="-300.25">
            //        <valortag>trimestral</valortag>
            //    </tag>
            //    <tag totalAmount="-72"> 
            //        <valortag>shoes</valortag>
            //    </tag>
            //    <tag totalAmount="-72">
            //        <valortag>clothes</valortag>
            //    </tag>
            //    <tag totalAmount="-72">
            //        <valortag>personal</valortag>
            //    </tag>
            //    <tag totalAmount="1520">
            //        <valortag>salary</valortag>
            //    </tag>
            //    <tag totalAmount="1520">
            //        <valortag>job</valortag>
            //    </tag>
            //    <tag totalAmount="-400">
            //        <valortag>mortgage</valortag>
            //    </tag>
            //    <tag totalAmount="-400">
            //        <valortag>mensual</valortag>
            //    </tag>
            //</result>
            RESTClient clientWs = new RESTClient();
            string strProjectId = projectId.HasValue ? projectId.Value.ToString() : String.Empty;
            string xmlData = clientWs.MakeRequest("getTags?project=" + strProjectId, _user, _password);
            XmlSerializer serialize = new XmlSerializer(typeof(ResultTags));
            ResultTags result = (ResultTags)serialize.Deserialize(new StringReader(xmlData));
            return new List<Tag>(result.Tags);
        }
    }
}
