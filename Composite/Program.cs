using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hiyerarşik bir yapı kurmamızı sağlayan desen. Ağaç yapısı gibi. En üstte bir dal ve o dala bağlı alt dallar.



            Employee ibrahim = new Employee() { Name = "İbrahim Öztürk" };
            Employee emir = new Employee() { Name = "Emir Öztürk" };
            Employee huseyin = new Employee() { Name = "Hüseyin Yılmaz" };
            Employee ahmet = new Employee() { Name = "Ahmet Dursun" };

            ibrahim.AddSubordinate(emir);
            ibrahim.AddSubordinate(huseyin);
            ibrahim.AddSubordinate(ahmet);

            emir.AddSubordinate(huseyin);
            emir.AddSubordinate(ahmet);

            foreach (Employee person in ibrahim)
            {
                var item1 = person.Name;
                Console.WriteLine($" {item1}");

                foreach (IPerson subperson in person)
                {
                    var item2 = subperson.Name;
                    Console.WriteLine($"    {item2}");
                }
                

            }

            Console.ReadKey();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
