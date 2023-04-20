using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder1 = new NewCustomersProductBuilder();
            director.GenerateProduct(builder1);
            var model = builder1.GetModel();

            ProductDirector director2 = new ProductDirector();
            var builder2 = new OldCustomersProductBuilder();
            director2.GenerateProduct(builder2);
            var model2 = builder2.GetModel();

            Console.WriteLine($"{model.Id}\n{model.CategoryName}\n{model.ProductName}\n{model.UnitPrice}\n{model.DiscountedPrice}");
            Console.WriteLine($"{model2.Id}\n{model2.CategoryName}\n{model2.ProductName}\n{model2.UnitPrice}\n{model2.DiscountedPrice}");

            Console.ReadKey();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool IsDiscounted { get; set; }
    }
    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }
    class NewCustomersProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.IsDiscounted = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }
    class OldCustomersProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.IsDiscounted = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}