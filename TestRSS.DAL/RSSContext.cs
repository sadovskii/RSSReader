using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRSS.DAL.ModelsDAL;

namespace TestRSS.DAL
{
    class RSSContext : DbContext
    {
        public RSSContext()
            : base("DbConnection")
        { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<RSSFeed> RSSFeeds { get; set; }


    }
}
