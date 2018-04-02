using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRSS.DAL.ModelsDAL
{
    public class RSSFeed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public ICollection<Article> Articles { get; set; }
        public RSSFeed()
        {
            Articles = new List<Article>();
        }
    }
}
