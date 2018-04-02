using AutoMapper;
using RSSReaderWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestRSS.BLL.DTO;

namespace RSSReaderWEB.Util
{
    public class AutomapperProfileWEB : Profile
    {
        public AutomapperProfileWEB()
        {
            CreateMap<RSSFeedDTO, RSSFeedViewModel>();
            CreateMap<RSSFeedViewModel, RSSFeedDTO>();
            CreateMap<ArticleViewModel, ArticleDTO>();
            CreateMap<ArticleDTO, ArticleViewModel>();
        }
    }
}