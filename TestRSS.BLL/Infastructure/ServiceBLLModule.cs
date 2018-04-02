using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRSS.DAL.Interfaces;
using TestRSS.DAL.Repositories;

namespace TestRSS.BLL.Infastructure
{
    public class ServiceBLLModule : NinjectModule
    {
        public override void Load()
        {
            //Bind(Type.GetType("TestRSS.DAL.RSSContext, TestRSS.DAL")).ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<EFUnitOfWork>();
        }
    }
}
