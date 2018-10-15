using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using KattisUtilities;
using KattisUtilities.HTML;
using KattisUtilities.Rest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKattisUploader
{
    [TestClass]
    public class TestUtilities
    {
        //[TestMethod]
        //public void TestKattisProblemCreate()
        //{
        //    /*    <title>Bee House Perimeter</title>
        //          <link>https://open.kattis.com/problems/beehouseperimeter</link>
        //          <guid>https://open.kattis.com/problems/beehouseperimeter</guid>
        //          <pubDate>Sat, 15 Sep 2018 04:00:00 +0200</pubDate> 
        //    */
        //    /*
        //     * XElement contacts =  
        //        new XElement("Contacts",  
        //            new XElement("Contact",  
        //                new XElement("Name", "Patrick Hines"),   
        //                new XElement("Phone", "206-555-0144"),  
        //                new XElement("Address",  
        //                    new XElement("Street1", "123 Main St"),  
        //                    new XElement("City", "Mercer Island"),  
        //                    new XElement("State", "WA"),  
        //                    new XElement("Postal", "68042")  
        //                )  
        //            )  
        //     * */
        //    XElement xElement = new XElement("item",
        //                        new XElement("title", "Bee House Perimeter"),
        //                        new XElement("link", "https://open.kattis.com/problems/beehouseperimeter"),
        //                        new XElement("guid", "https://open.kattis.com/problems/beehouseperimeter"),
        //                        new XElement("pubDate", "Sat, 15 Sep 2018 04:00:00 +0200")
        //                        );
        //    XmlElement xe = xElement;
        //    KattisFromRSSItem kp = new KattisFromRSSItem(xe);
        //    Assert.AreEqual(kp.Title, "Bee House Perimeter");
        //    Assert.AreEqual(kp.Link, "https://open.kattis.com/problems/beehouseperimeter");
        //    Assert.AreEqual(kp.ID, "beehouseperimeter");
        //    ///Assert.AreEqual(kp.PubDate.Date, DateTime.Parse("Sat, 15 Sep 2018 04:00:00 +0200"));


        //}

        [TestMethod]

        public async Task TestAsyncLoginEmail()

        {
            Tasks t = new Tasks();
            bool b = await t.LoginAsync("mark.d.wardell@gmail.com", "Atlanta1960!");
            Assert.AreEqual(b, true);



        }
        [TestMethod]

        public async Task TestAsyncLogin()

        {
            Tasks t = new Tasks();
            bool b = await t.LoginAsync("mark-wardell", "Atlanta1960!");
            Assert.AreEqual(b, true);

            

        }
        [TestMethod]
        public async Task TestAsyncLoginShouldFail()

        {
            Tasks t = new Tasks();
            bool b = await t.LoginAsync("mark-wardell", "XXX!");
            Assert.AreEqual(b, false);



        }

        [TestMethod]

        public async Task TestAsyncUpLoad()

        {
            Tasks t = new Tasks();
            bool b = await t.LoginAsync("mark-wardell", "Atlanta1960!");
            Assert.AreEqual(b, true);

            Assert.AreEqual(true, File.Exists("Hello.cs"));
           
            b = await t.SubmitAsync("hello.cs");
            Assert.AreEqual(b, true);



        }

        [TestMethod]

        public async Task TestAsyncUpLoadShooldFailBecauseFileDoesNotExist()

        {
            Tasks t = new Tasks();
            bool b = await t.LoginAsync("mark-wardell", "Atlanta1960!");
            Assert.AreEqual(b, true);

            Assert.AreEqual(false, File.Exists("Hello.cpp"));

            b = await t.SubmitAsync("hello.cpp");
            Assert.AreEqual(b, false);



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
            foreach (string page in s.HTMLPages)
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
