using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRSS.DAL.ModelsDAL;

namespace TestRSS.BLL.DTO
{
    public class RSSFeedDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        
    }
}
