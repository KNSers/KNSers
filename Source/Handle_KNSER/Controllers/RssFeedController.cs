using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ServiceModel.Syndication;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Xml;

namespace Handle_KNSER.Models
{
    public class RssFeedController : ApiController
    {

        /// create the XML RSS file
       /* public XmlElement createFakeRSS(List<InfomationModel> ListInfo)
        {
            // create fake rss feed
            HtmlDocument doc = new HtmlDocument();
            XmlDocument rssDoc = new XmlDocument();
            rssDoc.LoadXml("<?xml version=\"1.0\" encoding=\"" + doc.Encoding.BodyName + "\"?><rss version=\"0.91\"/>");

            // add channel element and other information
            XmlElement channel = rssDoc.CreateElement("channel");
            rssDoc.FirstChild.NextSibling.AppendChild(channel);

            XmlElement temp = rssDoc.CreateElement("title");
            temp.InnerText = "ASP.Net articles scrap RSS feed";
            channel.AppendChild(temp);

            temp = rssDoc.CreateElement("link");
            temp.InnerText = "";
            channel.AppendChild(temp);

            XmlElement item;
            // browse each article
            foreach (var info in ListInfo)
            {
                // get what's interesting for RSS
                //string link = href.Attributes["href"].Value;
                //string title = href.InnerText;
                //string description = null;
                //HtmlNode descNode = href.SelectSingleNode("../div/text()");
                //if (descNode != null)
                //    description = descNode.InnerText;

                // create XML elements
                item = rssDoc.CreateElement("item");
                channel.AppendChild(item);

                temp = rssDoc.CreateElement("title");
                temp.InnerText = info.Title;
                item.AppendChild(temp);

                temp = rssDoc.CreateElement("publish");
                temp.InnerText = info.CreateAt.ToString();
                item.AppendChild(temp);                
            }
            rssDoc.Save("rss.xml");
            return channel;
        }
        */
        
        [HttpGet]
        public Rss20FeedFormatter Get()
        {
            var feed = new SyndicationFeed("KNSERS", "Events", new Uri("http://www.fit.hcmus.edu.vn/vn/Default.aspx?tabid=97"));
            feed.Authors.Add(new SyndicationPerson("htluan2811@gmail.com"));
            feed.Categories.Add(new SyndicationCategory("Ticket Box"));
            feed.Description = new TextSyndicationContent("Event Infomation");


            List<InfomationModel> ListOfInfo = new List<InfomationModel>();

            ListOfInfo = Html2Rss();

            List<SyndicationItem> RssItems = new List<SyndicationItem>();

            foreach (var item in ListOfInfo)
            {
                SyndicationItem rss = new SyndicationItem(
               item.Title,
               item.CreateAt.ToString(),                
               new Uri("http://www.fit.hcmus.edu.vn/vn/Default.aspx?tabid=97"),
               "",
               DateTime.Now);

               RssItems.Add(rss);
            }
            feed.Items = RssItems;
            //var ret = feed.GetRss20Formatter();
            var ret = feed.GetRss20Formatter();
            return new Rss20FeedFormatter(feed);
        }


        public List<InfomationModel> Html2Rss()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb hw = new HtmlWeb();
            doc = hw.Load("http://www.fit.hcmus.edu.vn/vn/Default.aspx?tabid=97");
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table[@id=\"dnn_ctr785_ViewNews_ucShowPost_tblShowListOne\"]/tr[1]/td[1]/table");

            List<InfomationModel> ListInfo = new List<InfomationModel>();
            foreach (var item in nodes)
            {
                InfomationModel Info = new InfomationModel();
                
                // get Title
                Info.Title = item.SelectSingleNode("tr[1]/td[2]/a").InnerText; 

                // get Publish Date
                Info.CreateAt = DateTime.ParseExact(item.SelectSingleNode("tr[1]/td[2]/span").InnerText.Trim().Replace("(", "").Replace(")", ""), "dd/MM/yyyy", null);
                ListInfo.Add(Info);
            }
            return ListInfo.ToList();

        }

        #region Helper
        public HttpResponseMessage CreateResponse<T>(HttpStatusCode StatusCode, T Data)
        {
            return Request.CreateResponse(StatusCode, Data);
        }
        public HttpResponseMessage CreateResponse(HttpStatusCode httpStatusCode)
        {
            return Request.CreateResponse(httpStatusCode);
        }
        #endregion
    }
}
