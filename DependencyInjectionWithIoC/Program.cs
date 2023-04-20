using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionWithIoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Farklı IoC Containerlar var:
             
             * Unity
             * StructureMap
             * Castle Windsor
             ** Ninject --> Kullanacağız
             * Autofac
             * DryIoc
             * Simple Injector
             * Light Inject
             
             */

            IKernel kernelEf = new StandardKernel();
            kernelEf.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            //ProductManager productManagerWithEf = new ProductManager(new EfProductDal());
            ProductManager productManagerWithEf = new ProductManager(kernelEf.Get<IProductDal>());
            productManagerWithEf.Save();

            IKernel kernelNh = new StandardKernel();
            kernelNh.Bind<IProductDal>().To<NhProductDal>().InSingletonScope();

            //ProductManager productManagerWithNh = new ProductManager(new NhProductDal());
            ProductManager productManagerWithNh = new ProductManager(kernelNh.Get<IProductDal>());
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

            _productDal.Save();
        }
    }
}
