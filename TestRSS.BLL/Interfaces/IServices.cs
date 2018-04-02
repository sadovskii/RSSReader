using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRSS.BLL.DTO;
using TestRSS.BLL.Services;

namespace TestRSS.BLL.Interfaces
{
    public interface IServices
    {
        IEnumerable<ArticleDTO> GetEllemetArticles(int id);
        Result ReadAndSaveArticlesFromRSS(RSSFeedDTO RSSFeed);
        void CreateNewRSSFeed(RSSFeedDTO sSFeedDTO);
        IEnumerable<RSSFeedDTO> GetAllEllemetsRSSFeeds();
        IEnumerable<ArticleDTO> GetAllEllemetsArticles();
    }
}
