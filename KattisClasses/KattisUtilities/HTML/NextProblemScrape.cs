using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisUtilities.HTML
{
    public class NextProblemScrape
    {
        
        public static string GetNextProblemPage(string page)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page);
            var findAnchors = doc.DocumentNode.Descendants("a");
            var n = findAnchors.First();
            var o = findAnchors.Last();
            List<string> strList = new List<string>();
            var node = findAnchors.Where(d => d.InnerText.Contains("Next")).First();
           
            string hrefValue = node.GetAttributeValue("href", String.Empty);



            return hrefValue;
        }
    }
}
