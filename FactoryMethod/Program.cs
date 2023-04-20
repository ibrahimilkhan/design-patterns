using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Günümüzde en sık kullanılan design patternlardan bir tanesidir. 
             * Amaç: Yazılımdaki değişimi kontrol altında tutabilmek,değişkenlik gösterebilecek teknolojilerin implementasyonunu kolaylaştırabilmek
            */

            CustomerManager manager = new CustomerManager(new LoggerFactory2());
            manager.Save();

            Console.ReadKey();
        }
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new MyLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public class MyLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with MyLogger");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }
    public interface ILogger
    {
        void Log();
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
