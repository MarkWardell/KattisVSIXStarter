using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisUtilities.HTML
{
    public abstract class AbstractPageIterator
    {
        private string nextPageName = string.Empty;
        public virtual string NextPageName {    get { return GetNextPagName();  }
                                                set { nextPageName = value;     }
        }
        public virtual async Task<string> GetPage(string url)
        {

            await Task.Delay(10);
            return String.Empty;

        }
        
        protected abstract string GetNextPagName(string prepend = null);
        
    }

    public class FileIterator : AbstractPageIterator
    {
        public FileIterator(string folder)
        {

        }
        public override Task<string> GetPage(string page)
        {
            return base.GetPage(page);
        }


        protected override string GetNextPagName(string prefixPrepend = "")
        {
            throw new NotImplementedException();
        }
    }

    public class UrlIterator : AbstractPageIterator
    {
        private string page = String.Empty;
        string prefix = string.Empty;
        public UrlIterator(string prepend = "")
        {
            prefix = prepend;
        }
        public  override async Task<string> GetPage(string url)
        {
            UrlItem urlItem = new UrlItem(url);
            int n = await urlItem.Grab();
            page = urlItem.Html;
            return page;

        }
        protected override string GetNextPagName(string prefixPrepend = "" )
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml (page);
            var findAnchors = doc.DocumentNode.Descendants("a");
            var node = findAnchors.Where(d => d.InnerText.Contains("Next")).FirstOrDefault();
            if (node == null)
                return string.Empty;
            else
            { 
                string hrefValue = node.GetAttributeValue("href", String.Empty);
                if (hrefValue == string.Empty)
                    return string.Empty;
                else
                    return $"{prefix}{hrefValue}";
            }
           
        }
    }


}
