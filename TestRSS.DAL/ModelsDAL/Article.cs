using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRSS.DAL.ModelsDAL
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public DateTime PublicationDate { get; set; }
        public string DescriptionOfTheNews { get; set; }
        public int? RSSFeedId { get; set; }
        public RSSFeed RSSFeed { get; set;}

    }
}
