using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSSReaderWEB.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public DateTime PublicationDate { get; set; }
        public string DescriptionOfTheNews { get; set; }
        public int? RSSFeedId { get; set; }
    }
}