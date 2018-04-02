using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestRSS.BLL.Interfaces;
using TestRSS.BLL.Services;

namespace RSSReaderWEB.Util
{
    public class ServiceWEBModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IServices>().To<Services>();
        }
    }
}