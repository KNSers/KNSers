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
            var feed = new SyndicationFeed("KNSERS", "Events", new Uri("https://ticketbox.vn/events"));
            feed.Authors.Add(new SyndicationPerson("htluan2811@gmail.com"));
            feed.Categories.Add(new SyndicationCategory("Ticket Box"));
            feed.Description = new TextSyndicationContent("Vé hòa nhạc, vé hội thảo, vé sự kiện, vé thể thao ở Việt Nam | TicketBox");


            List<InfomationModel> ListOfInfo = new List<InfomationModel>();

            ListOfInfo = Html2Rss();

            List<SyndicationItem> RssItems = new List<SyndicationItem>();

            foreach (var item in ListOfInfo)
            {
                SyndicationItem rss = new SyndicationItem(
               item.Title,
               item.CreateAt.ToString(),
               new Uri(item.WebsiteLink),
               "",
               DateTime.Now);

                RssItems.Add(rss);
            }
            feed.Items = RssItems;
            //var ret = feed.GetRss20Formatter();
            var ret = feed.GetRss20Formatter();
            return new Rss20FeedFormatter(feed);
        }

        [HttpGet]
        [Route("api/RssFeed/rss")]
        public IHttpActionResult getRss()
        {
            List<InfomationModel> ListOfInfo = new List<InfomationModel>();

            ListOfInfo = Html2Rss();
            return Ok(ListOfInfo);
        }

        public List<InfomationModel> Html2Rss()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb hw = new HtmlWeb();
            doc = hw.Load("https://ticketbox.vn/events");
            HtmlNodeCollection TitleNode = doc.DocumentNode.SelectNodes("//div[@class=\"table-cell event-title\"]/a");

            // get other
            //HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@data-event-list-container=\"true\"]/div");

            List<InfomationModel> ListInfo = new List<InfomationModel>();
            foreach (var item in TitleNode)
            {
                InfomationModel Info = new InfomationModel();
                string title = item.GetAttributeValue("title", "").Trim();
                Info.Title = modifyTicketBoxTitle(title);

                string href = item.GetAttributeValue("href", "").Trim();
                Info.WebsiteLink = href;
                ListInfo.Add(Info);
            }


            return ListInfo.ToList();

        }

        public string modifyTicketBoxTitle(string text = "")
        {
            string NewString = "";
            text = text.Replace("&quot", "");
            NewString = text;
            return NewString;
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
