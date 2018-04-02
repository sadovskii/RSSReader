using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRSS.DAL.Interfaces;
using TestRSS.DAL.ModelsDAL;

namespace TestRSS.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private RSSContext db = new RSSContext();
        private EFGenericRepository<RSSFeed> RSSFeedRepository;
        private EFGenericRepository<Article> ArticleRepository;
        public IGenericRepository<RSSFeed> RSSFeed
        {
            get
            {
                if (RSSFeedRepository == null)
                    RSSFeedRepository = new EFGenericRepository<RSSFeed>(db);
                return RSSFeedRepository;
            }
        }

        public IGenericRepository<Article> Article
        {
            get
            {
                if (ArticleRepository == null)
                    ArticleRepository = new EFGenericRepository<Article>(db);
                return ArticleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
