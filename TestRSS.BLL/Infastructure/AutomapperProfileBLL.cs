using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRSS.BLL.DTO;
using TestRSS.DAL.ModelsDAL;

namespace TestRSS.BLL.Infastructure
{
    public class AutomapperProfileBLL : Profile
    {
        public AutomapperProfileBLL()
        {
            CreateMap<RSSFeedDTO, RSSFeed>();
            CreateMap<RSSFeed, RSSFeedDTO>();
            CreateMap<Article, ArticleDTO>();
            CreateMap<ArticleDTO, Article>();
        }
    }
}
