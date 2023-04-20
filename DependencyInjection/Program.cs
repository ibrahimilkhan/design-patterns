using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SOLID --> Dependency Inversion --> Bu prensibi ayağa kaldıran desenlerden bir tanesidir. Katmanlar arası geçiş yaparken bu desenden faydalanırız.

            // Örn: Data Access ile Business arasında bağımlılık sıfırlanmalıdır. UI ile Business arasındaki bağımlılık da aynı şekilde...

            // Bir nesnenin başka bir nesneye bağımlılığı olmamalıdır.

            // Bu deseni daha efektif hale getiren araçlar: IoC Containers 

            ProductManager productManagerWithEf = new ProductManager(new EfProductDal());
            productManagerWithEf.Save();

            ProductManager productManagerWithNh = new ProductManager(new NhProductDal());
            productManagerWithNh.Save();

            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF!");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with NHibernate!");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
                /* Olmaması Gereken:
                 
            ProductDal productDal = new ProductDal();
            productDal.Save();

                Newlemek yerine constructor'dan almalıyız. Böylece ProductManager'dan nesne üretirken hangi IProductDal nesnesi ile çalışacağımızı kendimiz belirleyebiliriz ve bağımlılığımız kalmaz. */

            _productDal.Save();
        }
    }
}
