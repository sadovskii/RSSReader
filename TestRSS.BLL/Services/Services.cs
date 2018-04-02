using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestRSS.BLL.DTO;
using TestRSS.BLL.Infastructure;
using TestRSS.BLL.Interfaces;
using TestRSS.DAL.Interfaces;
using TestRSS.DAL.ModelsDAL;
using TestRSS.DAL.Repositories;

namespace TestRSS.BLL.Services
{
    public class Result
    {
        public int KolReadNews { get; set; }
        public int KolSavedNews { get; set; }
        public string StatusRequest { get; set; }  
    }
    public class Services : IServices
    {
        IUnitOfWork Db { get; set; }
        private const int NumberOfRetries = 10;
        public Services(IUnitOfWork uow)
        {
            Db = uow;
        }
        public Result ReadAndSaveArticlesFromRSS(RSSFeedDTO RSSFeed)
        {
            if (RSSFeed != null)
            {
                Result result = new Result { KolReadNews = 0, KolSavedNews = 0 };
                for (int i = 0; i < NumberOfRetries; i++)
                {
                    try
                    {
                        XmlDocument xd = new XmlDocument();
                        xd.PreserveWhitespace = false;
                        xd.Load(@RSSFeed.URL);
                        
                        //var c = xd.GetElementById(" ");
                        //xd.RemoveChild(c);
                        XmlReader r = new XmlNodeReader(xd);

                        var articles = SyndicationFeed.Load(r);

                        var itemsOfArticles = articles.Items;
                        foreach (var t in itemsOfArticles)
                        {
                            if (!(IsThisArticleInDb(t.Title.Text, t.PublishDate.DateTime, RSSFeed)))
                            {
                                Article article = new Article();
                                article.Title = t.Title.Text;
                                article.URL = t.Links[0].Uri.ToString();
                                article.PublicationDate = t.PublishDate.DateTime;
                                article.DescriptionOfTheNews = t.Summary.Text;
                                article.RSSFeed = Db.RSSFeed.FindOneElement(k => k.URL == RSSFeed.URL);
                                Db.Article.Create(article);
                                Db.Save();
                                result.KolSavedNews++;
                            }
                            result.KolReadNews++;
                        }
                        result.StatusRequest = "All right";
                        return result;
                    }
                    catch(Exception e)
                    {
                        result.StatusRequest = "Error!!!   " + e.Message;
                    }
                }
                return result;
            }
            else
                return null;
        }
        private bool IsThisArticleInDb(string title, DateTime dateTime, RSSFeedDTO rSSFeedDTO)
        {
            var list = Db.Article.FindList(t => t.RSSFeed.URL == Mapper.Map<RSSFeedDTO, RSSFeed>(rSSFeedDTO).URL);
            foreach(var a in list)
                if (a.Title == title && a.PublicationDate == dateTime)
                    return true;
            return false;
        }
        public void CreateNewRSSFeed(RSSFeedDTO sSFeedDTO)
        {
            int counter = 0;
            var list = Db.RSSFeed.GetAll();
            foreach(var a in list)
                if (a.URL == sSFeedDTO.URL)
                    counter++;
            if(counter == 0)
            {
                Db.RSSFeed.Create(Mapper.Map<RSSFeedDTO, RSSFeed>(sSFeedDTO));
                Db.Save();
            }
        }
        public IEnumerable<RSSFeedDTO> GetAllEllemetsRSSFeeds()
        {
            var rss = Db.RSSFeed.GetAll();
            return Mapper.Map<IEnumerable<RSSFeed>, List<RSSFeedDTO>>(rss);
        }
        public IEnumerable<ArticleDTO> GetAllEllemetsArticles()
        {
            var articles = Db.Article.GetAll();
            return Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(articles);
        }
        public IEnumerable<ArticleDTO> GetEllemetArticles(int id)
        {
            var articles = Db.Article.FindList(t => t.RSSFeedId == id);
            return Mapper.Map<IEnumerable<Article>, List<ArticleDTO>>(articles);
        }
    }
}
