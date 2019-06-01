using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication1
{
    public class crawl
    {
        public void crawl_gsm(string text)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://www.gsmarena.com/res.php3?sSearch=" + text);

            ///   request.UserAgent = "A .NET Web Crawler";

            ///after installing the package you need to make a web request to the websites on whom you wish your crawler crawl and collect data.

            WebResponse response = request.GetResponse();

            List<product_info> P = new List<product_info>();

            Stream stream = response.GetResponseStream();



            StreamReader reader = new StreamReader(stream);

            var htmlText = reader.ReadToEnd();
            //till this line all we do is read the web document of the desired page.
            var htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(htmlText);
            //once the document is completely read below is an example if i want to read a specific portion of
            //the document such as a comment or the price of a product
            //below mentioned line of code simply moves to the corresponding element in the webpage and extracts the data I want.
            var link = htmldocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("makers")).ToList();
            string ext;
            ///   
            link = link[0].Descendants("li").ToList();
            try { 
            foreach (var l in link)
            {

                ext = l.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
                product_info p = new product_info();
                request = (HttpWebRequest)WebRequest.Create(" https://www.gsmarena.com/" + ext.ToString());
                response = request.GetResponse();
                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                htmlText = reader.ReadToEnd();
                htmldocument = new HtmlDocument();
                htmldocument.LoadHtml(htmlText);


                    var pimg = htmldocument.DocumentNode.Descendants("div")
                            .Where(node => node.GetAttributeValue("class", "").Equals("specs-photo-main")).LastOrDefault().ChildNodes.ToList();
                    p.imgurl = pimg[1].Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value;
                    var pname = htmldocument.DocumentNode.Descendants("div")
                   .Where(node => node.GetAttributeValue("class", "").Equals("article-info-line page-specs light border-bottom")).ToList();
                foreach (var y in pname)
                {
                    p.name = y.Descendants("h1").FirstOrDefault().InnerHtml;
                }


                var pprice = htmldocument.DocumentNode.Descendants("td").Where
                    (node => node.GetAttributeValue("class", "").Equals("nfo")).ToList();


                /// p.price = pprice[pprice.Count - 7].InnerText;

                //=System.Text.RegularExprfor()foreach (var z in pprice)
                for (int j = 0; j < pprice.Count; j++)
                {
                    if (pprice[j].InnerText.Contains("EUR") == true)
                    {
                        string url = pprice[j].InnerText;
                        url = System.Text.RegularExpressions.Regex.Replace(url, "[^0-9]+", string.Empty);
                        string price = (double.Parse(url) * 122).ToString();
                        p.price = price;
                        break;
                    }
                }



                List<string> comments = new List<string>();
                var zz = htmldocument.DocumentNode.Descendants("p")
                    .Where(node => node.GetAttributeValue("class", "").Equals("uopin")).ToList();
                List<double> d = new List<double>();
                foreach (var com in zz)
                {
                    //  comments.Add(com.InnerHtml.ToString());
                    ///NLP.init();
                    d.Add(NLP.computeSentiment(com.InnerHtml.ToString()));

                }
                double avg = 0;
                int i;
                for (i = 0; i < d.Count; i++)
                {
                    avg = avg + d[i];
                }
                avg = avg / i;
                if (avg >= 5)
                {
                    avg = avg % 5;
                }
                p.rating = avg;
                    p.site = " https://www.gsmarena.com/" + ext.ToString();
                P.Add(p);
                ///new DAO().insertData(p);
            }
        }catch{}
            DAO dao = new DAO();
            for (int i = 0; i < P.Count; i++)
                dao.insertData(P[i]);
        }
        //////////////////////////////////////////////////////////////
        public void crawl_hamariweb(string text)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.hamariweb.com/mobiles/mobile_finder.aspx?q=" + text);
            request.CookieContainer = new CookieContainer();
            request.Method = "GET";
            request.AllowAutoRedirect = true;
            WebResponse response;
            try
            {
                request.MaximumAutomaticRedirections = 100;
                response = request.GetResponse();
            }
            catch (Exception)
            {
                request.CookieContainer = new CookieContainer();
                request.AllowAutoRedirect = true;
                request.Method = "GET";
                response = request.GetResponse();
            }
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var htmlText = reader.ReadToEnd();
            var htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(htmlText);
            var link = htmldocument.DocumentNode.Descendants("table")
    .Where(node => node.GetAttributeValue("id", "").Equals("MainPageContent_dlSMS")).ToList();
            //MainPageContent_dlSMS
            string ext;
            product_info p = new product_info();
            foreach (var l in link)
            {
                ext = l.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
                request = (HttpWebRequest)WebRequest.Create(" https://www.gsmarena.com/" + ext.ToString());
                response = request.GetResponse();
                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                htmlText = reader.ReadToEnd();
                htmldocument = new HtmlDocument();
                htmldocument.LoadHtml(htmlText);
                break;
            }
        }
        public void crawl_amazon(string text)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.amazon.com/s/ref=nb_sb_noss?url=search-alias%3Daps&field-keywords=" + text);
            WebResponse response;
            // request.MaximumAutomaticRedirections = 100;
            request.Proxy = null;
            response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var htmlText = reader.ReadToEnd();
            var htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(htmlText);
            htmldocument.LoadHtml(htmlText);
            var link = htmldocument.DocumentNode.Descendants("div")
    .Where(node => node.GetAttributeValue("class", "").Equals("s-item-container")).ToList();
            //MainPageContent_dlSMS
            string ext;
            product_info p = new product_info();
            foreach (var l in link)
            {
                ext = l.Descendants("a-link-normal s-access-detail-page  s-color-twister-title-link a-text-normal").FirstOrDefault().ChildAttributes("tiltle").FirstOrDefault().Value;
                request = (HttpWebRequest)WebRequest.Create(" https://www.gsmarena.com/" + ext.ToString());
                response = request.GetResponse();
                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                htmlText = reader.ReadToEnd();
                htmldocument = new HtmlDocument();
                htmldocument.LoadHtml(htmlText);
                break;
            }
        }
        public void crawl_daraz(string text)
        {

            //
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.daraz.pk/smartphones/?q=" + text);
            WebResponse response;
            // request.MaximumAutomaticRedirections = 100;
            request.Proxy = null;
            response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var htmlText = reader.ReadToEnd();
            var htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(htmlText);
            htmldocument.LoadHtml(htmlText);
            var link = htmldocument.DocumentNode.Descendants("div")
    .Where(node => node.GetAttributeValue("class", "").Equals("sku -gallery ")).ToList();
            //MainPageContent_dlSMS
            int count = 0;
            List<product_info> P = new List<product_info>();


            foreach (var l in link)
            {
                product_info p = new product_info();
                var v = l.ChildNodes[1].Descendants("img")
                    .Where(node => node.GetAttributeValue("class", "").Equals("image")).ToList();
             string original_text =   v[0].OuterHtml.ToString();
                p.imgurl = Regex.Match(original_text, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;

                var ext = l.ChildNodes[1].Descendants("span")
                    .Where(node => node.GetAttributeValue("class", "").Equals("name")).ToList();

                ///p.name = ext[0].InnerHtml.ToString();
                ext = l.ChildNodes[1].Descendants("span")
                    .Where(node => node.GetAttributeValue("dir", "").Equals("ltr")).ToList();
                p.price = ext[1].InnerHtml.ToString();
                //p.site = "daraz.pk";
                //P.Add(p);
                var real = l.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
                var inhtmldoc = new HtmlDocument();
                request = (HttpWebRequest)WebRequest.Create(real.ToString());
                // response;
                // request.MaximumAutomaticRedirections = 100;
                request.Proxy = null;
                response = request.GetResponse();

                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                htmlText = reader.ReadToEnd();
                inhtmldoc.LoadHtml(htmlText);
                p.site = real.ToString();
                try
                {
                    ///"\nAverage Rating 4,4Based on 5 ratings"
                    var ratin = inhtmldoc.DocumentNode.Descendants("article")
        .Where(node => node.GetAttributeValue("class", "").Equals("avg")).ToList();
                    string rate = ratin[0].InnerText;
                    if (rate.Contains(','))
                    {
                        string[] k = rate.Split(',');
                    }
                    for (int i = 0; i < rate.Length; i++)
                    {
                        if (rate[i] == '0' || rate[i] == '1' || rate[i] == '2' || rate[i] == '3' || rate[i] == '4' || rate[i] == '5' || rate[i] == '6' || rate[i] == '7' || rate[i] == '8' || rate[i] == '9')
                        {
                            p.rating = double.Parse(rate[i].ToString());
                            P.Add(p);
                            break;
                        }
                    }

                }
                catch
                {
                    p.rating = 0;
                    P.Add(p);
                }
            }

            DAO dao = new DAO();
            for (int i = 0; i < P.Count; i++)
            {
                dao.insertData(P[i]);
            }

        }
        public void crawl_whatmobile(string text)
        {
            //
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.whatmobile.com.pk/reviews/?s=" + text);
            WebResponse response;
            // post-img small-post-img
            request.Proxy = null;
            response = request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            var htmlText = reader.ReadToEnd();
            var htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(htmlText);
            htmldocument.LoadHtml(htmlText);
            var link = htmldocument.DocumentNode.Descendants("div")
.Where(node => node.GetAttributeValue("class", "").Equals("post-img small-post-img")).ToList();
            List<product_info> P = new List<product_info>();
            foreach (var l in link)
            {
                string ext = l.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;
                request = (HttpWebRequest)WebRequest.Create(ext);
                // response;
                // post-img small-post-img
                request.Proxy = null;
                response = request.GetResponse();

                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                htmlText = reader.ReadToEnd();
                HtmlDocument inhtmldoc = new HtmlDocument();
                inhtmldoc.LoadHtml(htmlText);
                ///var newlink=inhtmldoc.DocumentNode.Descendants("a").
                var next = inhtmldoc.DocumentNode.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Equals("specsButtons")).ToList();
                request = (HttpWebRequest)WebRequest.Create(next[0].Descendants("a").LastOrDefault().ChildAttributes("href").FirstOrDefault().Value.ToString());
                var name = next[0].Descendants("a").LastOrDefault().ChildAttributes("href").FirstOrDefault().Value.ToString();

                request.Proxy = null;
                string[] v2 = name.Split('/');
                response = request.GetResponse();
                product_info p = new product_info();
                p.name = v2[3];
                stream = response.GetResponseStream();
                reader = new StreamReader(stream);
                htmlText = reader.ReadToEnd();
                HtmlDocument ininhtml = new HtmlDocument();
                ininhtml.LoadHtml(htmlText);
                var yo = ininhtml.DocumentNode.Descendants("div").
                    Where(node => node.GetAttributeValue("class", "").Equals("Heading1")).ToList();

                ///// List<HtmlNode> hhh = new List<HtmlNode>();
                var pop = yo[2].InnerHtml;
                try
                {

                    var src = ininhtml.DocumentNode.Descendants("img")
                        .Where(node => node.GetAttributeValue("itemprop", "").Equals("image")).ToList();
                    var aaloo = src[0].ChildAttributes("src").FirstOrDefault().Value;
                    var xy = yo[2].Descendants("h1").
                         Where(node => node.GetAttributeValue("class", "").Equals("Heading1")).ToList();
                    var jojo = yo[2].Descendants("td").
                        Where(node => node.GetAttributeValue("class", "").Equals("fasla")).ToList();
                    //   var hoho=jojo[0];
                    string price = jojo[jojo.Count - 2].InnerText;
                    string rate = jojo[jojo.Count - 1].InnerText;
                    //     product_info p = new product_info();
                    string[] arr = price.Split('&');
                    string[] arr1 = arr[0].Split(' ');
                    p.price = arr1[3];
                    string[] arr3 = rate.Split(' ');
                    p.rating = double.Parse(arr3[3].ToString());
                    p.site = next[0].Descendants("a").LastOrDefault().ChildAttributes("href").FirstOrDefault().Value.ToString();
                    P.Add(p);

                }
                catch
                {
                    var jojo = yo[2].Descendants("td").
                       Where(node => node.GetAttributeValue("class", "").Equals("fasla RowBG1 bottom-border-section right-border specs-subHeading")).ToList();
                    //   var hoho=jojo[0];
                    string price = jojo[0].InnerText;
                    string rate = jojo[1].InnerText;

                    string[] arr = price.Split('&');
                    string[] arr1 = arr[0].Split(' ');
                    p.price = arr1[3];
                    string[] arr3 = rate.Split(' ');
                    p.rating = double.Parse(arr3[3].ToString());
                    p.site = next[0].Descendants("a").LastOrDefault().ChildAttributes("href").FirstOrDefault().Value.ToString();

                    P.Add(p);
                }
            }

            DAO dao = new DAO();
            foreach (var p in P)
            { dao.insertData(p); }
        }
    }
}
