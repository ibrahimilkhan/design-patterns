using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager2 customerManager = new CustomerManager2();
            customerManager.Save();
            Console.ReadKey();
        }
    }
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Checked");
        }
    }
    public interface IAuthorize
    {
        void CheckUser();
    }

    public interface ILogging
    {
        void Log();
    }

    public interface ICaching
    {
        void Cache();
    }

    class CustomerManager // Böyle kullanmaktansa CustomerManager2 sınıfındaki gibi kullanabiliriz. Tamamen temiz kod yazma amaçlıydı.
    {
        private ILogging _logging;
        private ICaching _caching;
        private IAuthorize _authorize;
        public CustomerManager(ILogging logging, ICaching caching, IAuthorize authorize)
        {
            _logging = logging;
            _caching = caching;
            _authorize = authorize;
        }
        public void Save()
        {
            _logging.Log();
            _caching.Cache();
            _authorize.CheckUser();
            Console.WriteLine("Saved");
        }
    }

    class CustomerManager2
    {
        CrossCuttingConcernsFacade _concerns;
        public CustomerManager2()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }
        public void Save()
        {
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}

