using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoneyTrackinWS.Test
{
    [TestClass]
    public class WebServicesTest
    {
        MoneyTrackin money = new MoneyTrackin("salvarenu", "");

        [TestInitialize]
        public void Init()
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
            UserData ret = money.GetUserData();
            Assert.IsNotNull(ret);
        }

        [TestMethod]
        public void TestListProjects()
        {
            var projects = money.GetProjects();
            Assert.IsNotNull(projects);
        }

        [TestMethod]
        public void TestSerialize()
        {
            ResultProjects result = new ResultProjects();
            result.Code = "done";
            result.Items = new Project[2];
            result.Items[0] = new Project() { Id = "1", Name = "UNO", Balance = 123.23 };
            result.Items[1] = new Project() { Id = "2", Name = "DOS", Balance = 3523.3 };
            XmlSerializer serialize = new XmlSerializer(typeof(Project[]));
            StreamWriter sw = new StreamWriter("C:\\temp\\result,xml");
            serialize.Serialize(sw, result.Items);
            sw.Close();
        }

        [TestMethod]
        public void TestListTransactions()
        {
            var transactions = money.GetTransactions(null, new System.DateTime(2012, 6, 1), new System.DateTime(2012, 6, 30));
            Assert.IsNotNull(transactions);
        }

        [TestMethod]
        public void TestListTags()
        {
            var tags = money.GetTags(null);
            Assert.IsNotNull(tags);
        }
    }
}
