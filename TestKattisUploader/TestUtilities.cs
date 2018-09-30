using System;
using System.IO;
using System.Xml.Linq;
using KattisUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKattisUploader
{
    [TestClass]
    public class TestUtilities
    {
        [TestMethod]
        public void TestKattisProblemCreate()
        {
            /*    <title>Bee House Perimeter</title>
                  <link>https://open.kattis.com/problems/beehouseperimeter</link>
                  <guid>https://open.kattis.com/problems/beehouseperimeter</guid>
                  <pubDate>Sat, 15 Sep 2018 04:00:00 +0200</pubDate> 
            */
            /*
             * XElement contacts =  
                new XElement("Contacts",  
                    new XElement("Contact",  
                        new XElement("Name", "Patrick Hines"),   
                        new XElement("Phone", "206-555-0144"),  
                        new XElement("Address",  
                            new XElement("Street1", "123 Main St"),  
                            new XElement("City", "Mercer Island"),  
                            new XElement("State", "WA"),  
                            new XElement("Postal", "68042")  
                        )  
                    )  
             * */
            XElement xe = new XElement("item",
                                new XElement("title", "Bee House Perimeter"),
                                new XElement("link", "https://open.kattis.com/problems/beehouseperimeter"),
                                new XElement("guid", "https://open.kattis.com/problems/beehouseperimeter"),
                                new XElement("pubDate", "Sat, 15 Sep 2018 04:00:00 +0200")
                                );
            KattisFromRSSItem kp = new KattisFromRSSItem(xe);
            Assert.AreEqual(kp.Title, "Bee House Perimeter");
            Assert.AreEqual(kp.Link, "https://open.kattis.com/problems/beehouseperimeter");
            Assert.AreEqual(kp.ID, "beehouseperimeter");
            ///Assert.AreEqual(kp.PubDate.Date, DateTime.Parse("Sat, 15 Sep 2018 04:00:00 +0200"));


        }

        [TestMethod]
        public void TestKattisProblemFromFile()
        {
            KattisRSS kr = null;
            using (FileStream sourceStream = File.Open(@"..\..\KattisRSS.xml", FileMode.Open))
            {
                kr = new KattisRSS(sourceStream);
            }
            Assert.AreEqual(50, kr.Count);
            
        }
        //<td class="name_column"><a href="/problems/visual">Visual Python++</a></td>
       // [TestMethod]
        public void TestKattisProblemFromTD()
        {
            //var k = new KattisFromHTMLProblem("<td class=\"name_column\"><a href = \"/problems/visual\" > Visual Python++</a></td>");
            //Assert.IsNotNull(k);
        }
        

        [TestMethod]
        public void TestKattisProblemPageIteratorCreate()
        {
            var s = new KattisProblemPageGrabber();
            KattisHTMLScraper khtml = new KattisHTMLScraper();
            foreach (var page in s.HTMLPages)
                khtml.AppendProblemsOnPage(page);

            Assert.IsNotNull(s);

        }

        [TestMethod]
        public void TestLoadedHTMLPage()
        {
            KattisHTMLScraper kh;
            string text = System.IO.File.ReadAllText(@"..\..\KattisTestHTML.html");
            kh = new KattisHTMLScraper(text);
            Assert.AreEqual(100, kh.Count);

        }
    }
}
