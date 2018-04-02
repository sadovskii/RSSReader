using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRSS.DAL.ModelsDAL;

namespace TestRSS.BLL.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public DateTime PublicationDate { get; set; }
        public string DescriptionOfTheNews { get; set; }
        public int? RSSFeedId { get; set; }

    }
}
