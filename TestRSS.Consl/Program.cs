using AutoMapper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRSS.BLL.Infastructure;
using TestRSS.BLL.Interfaces;
using TestRSS.BLL.Services;

namespace TestRSS.Consl
{
    class Program
    {
        static void Main(string[] args)
        {
            Result result = new Result();
            IKernel kernal = new StandardKernel(new ServiceBLLModule());
            IServices service = kernal.Get<Services>();
            Mapper.Initialize(c => c.AddProfile<AutomapperProfileBLL>());

            Console.WriteLine("здравствуйте");
            Console.WriteLine("Вот перечень всех команд:");
            Console.WriteLine("-getRSS -- получить сохраненные RSS-источники");
            Console.WriteLine("-cnArticle -- проверить наличие новых статей в RSS-источниках");
            Console.WriteLine("-finish -- завершение работы программы");
            Console.WriteLine();


            while (true)
            {
                Console.Write("csharp> ");
                string line = Console.ReadLine();
                switch(line)
                {
                    case "-getRSS":
                        {
                            var listRSS = service.GetAllEllemetsRSSFeeds();
                            Console.WriteLine("Новости загружаются из следующих RSS-источников");
                            foreach (var a in listRSS)
                                Console.WriteLine("Название: {0}, ссылка: {1}", a.Name, a.URL);
                            Console.WriteLine();
                        }
                        break;
                    case "-cnArticle":
                        {
                            var listRSS = service.GetAllEllemetsRSSFeeds();
                            foreach (var a in listRSS)
                            {
                                Console.WriteLine("Название: " + a.Name);
                                Console.WriteLine("Ссылка: " + a.URL);
                                result = service.ReadAndSaveArticlesFromRSS(a);
                                Console.WriteLine("Количество прочитаных: {0}", result.KolReadNews);
                                Console.WriteLine("Количество сохраненных: {0}", result.KolSavedNews);
                                Console.WriteLine(result.StatusRequest);
                                Console.WriteLine();
                            }
                        }
                        break;
                    case "-finish":
                        {
                            Process.GetCurrentProcess().Kill();
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Данной команды не существует!");
                            Console.WriteLine();
                        }
                        break;
                }
            }

                
            


        }
    }
}
