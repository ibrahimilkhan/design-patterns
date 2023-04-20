using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Amaç: Nesne üretim maliyetini minimize etmek. Bu deseni her zaman kullanamıyoruz. Sadece ihtiyaçlar dahilinde...
            // Elimizde bir temel sınıftan mevcutsa onun prototopini oluşturup onun üzerinden yeni nesne üretim sürecini devam ettirebiliriz.
            // customer2 => customer1'i klonlayarak oluşturduk.
            // customer1 ve customer2 iki farklı nesne görevi görüyor ama new() diyerek yeni nesne oluşturmadığımız için kaynaktan tasarruf ettik.

            Customer customer1 = new Customer { FirstName = "İbrahim", LastName = "Öztürk", City = "İstanbul", Id = 1 };
            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Emir";

            Console.WriteLine(customer1.FirstName + customer1.LastName);
            Console.WriteLine(customer2.FirstName + customer2.LastName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
