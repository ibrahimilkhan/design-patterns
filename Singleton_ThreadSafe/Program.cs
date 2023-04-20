using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_ThreadSafe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Multi Thread çalışılan ortamlarda aynı nesneyi aynı anda iki kullanıcı isterse ve o nesne henüz üretilmemişse aynı anda iki nesne oluşturulur. Bu durumu defensive -veya safe- programming kapsamında Thread Safe Singleton ile engelleyebiliriz. 


        }
    }
    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();

        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {

            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }
    }
}
