using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRSS.DAL.ModelsDAL;

namespace TestRSS.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<RSSFeed> RSSFeed { get; }
        IGenericRepository<Article> Article { get; }
        void Save();
    }
}
