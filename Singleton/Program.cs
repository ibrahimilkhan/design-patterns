using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // BusinessLayer'da her bir sınıf için singleton desenini uygulamıyoruz. Bunun yerine Factory Pattern ile ortak bir çalışma gerçekleştirerek bu sınıf üzerinden işlerimizi hallediyoruz. 
            // IoC Containerların (Örn:Ninject) kullanımının yayınlaşmasıyla beraber burada yazdığımız singleton patternine has kodu yazmamız gerek kalmamıştır. 

            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();

            Console.ReadKey();
        }
    }
    class CustomerManager
    {
        /* 
        Sadece insert,update,delete işlemlerini yapacak bir sınıf olduğu için singletona uygun hale getirmek istiyoruz.
        1) Private constructer oluştur. 
        2) _customerManager adlı bir nesne yoksa bu nesneyi döndüren static bir metot oluştur.
        */

        private static CustomerManager _customerManager;
        private CustomerManager()
        {

        }
        public static CustomerManager CreateAsSingleton()
        {
            if (_customerManager == null)
            {
                _customerManager = new CustomerManager();
            }
            return _customerManager;

            // return _customerManager ?? (_customerManager = new CustomerManager());
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}
