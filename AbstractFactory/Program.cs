using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Amaç: Factorye ek olarak toplu nesne ihtiyaçlarında nesnelerin kullanımı kolaylaştırmak hem de standart durumlar için belirli nesnelere ihtiyaç duyuyorsak bu durumlara göre bir mantık çerçevesinde nesne üretmek. 

            ProductManager productManager = new ProductManager(new FactoryLog4AndMemCache());
            productManager.GetAll();
            Console.ReadLine();

            ProductManager productManager1 = new ProductManager(new FactoryLog4AndRedisCache());
            productManager1.GetAll();
            Console.ReadKey();

        }
    }
    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logger with Log4Net");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }
    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with RedisCache");
        }
    }

    /* 
     
     * Duruma Göre Nesne İhtiyaç Olasılıkları:
     * 1 - ) Log: Log4Net Cache: MemCache
     * 2 - ) Log: Log4Net Cache: RedisCache
     * 3 - ) Log: NLogger Cache: MemCache
     * 4 - ) Log: NLogger Cache: RedisCache 
     
     * Bu olasılıklara göre nesne üretecek fabrikamızı kuralım.
     
    */

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class FactoryLog4AndMemCache : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
        public override Caching CreateCaching()
        {
            return new MemCache();
        }
    }

    public class FactoryLog4AndRedisCache : CrossCuttingConcernsFactory
    {
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }

    // 1. ve 2. olaslık için ayrı ayrı fabrika kurduk. Şimdi bunları kullanacak Client'e ihtiyacımız var.

    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crosCuttingConcernFactory;

        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory crosCuttingConcernFactory)
        {
            _crosCuttingConcernFactory = crosCuttingConcernFactory;

            _logging = _crosCuttingConcernFactory.CreateLogger();
            _caching = _crosCuttingConcernFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("All Products Listed");
        }
    }
}
