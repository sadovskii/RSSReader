using AutoMapper;
using PagedList;
using RSSReaderWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestRSS.BLL.DTO;
using TestRSS.BLL.Interfaces;

namespace RSSReaderWEB.Controllers
{
    public class HomeController : Controller
    {
        IServices service;
        static IEnumerable<ArticleDTO> articlesListDTO;

        public HomeController(IServices serv)
        {
            service = serv;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PostRequest()
        {
            return View();
        }
        public ActionResult AjaxRequest()
        {
            var rssFeedDTO = service.GetAllEllemetsRSSFeeds();
            var rssFeedVM = Mapper.Map<IEnumerable<RSSFeedDTO>, List<RSSFeedViewModel>>(rssFeedDTO);
            return View(rssFeedVM);
        }
        public ActionResult GetArticles(int? page, int optionsRadios, int chooseSourse, int security)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (security == 1)
            {
                if (chooseSourse == -1)
                    articlesListDTO = service.GetAllEllemetsArticles();
                else
                    articlesListDTO = service.GetEllemetArticles(chooseSourse);
                if (optionsRadios == 1)
                {
                    articlesListDTO =  from u in articlesListDTO
                                       orderby u.PublicationDate
                                       select u;
                }
                if(optionsRadios == 2)
                {
                    articlesListDTO = from u in articlesListDTO
                                      orderby u.RSSFeedId
                                       select u;
                }
            }
            var articleVM = Mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articlesListDTO);
            return PartialView(articleVM.ToPagedList(pageNumber, pageSize));
        }
    }
}