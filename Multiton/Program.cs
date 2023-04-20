using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Singleton'ın farklı versiyonu Multiton

            // Singleton --> bir nesneden sadece bir tane üretileceği garanti edilir.
            // Multiton --> single nesneler sözlüğü

            Camera camera1 = Camera.GetCamera("x marka");
            Camera camera2 = Camera.GetCamera("x marka");
            Camera camera3 = Camera.GetCamera("y marka");
            Camera camera4 = Camera.GetCamera("y marka");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);

            // camera1 - camera2 ve camera3 - camera4 aynı nesnelerdir. 

            Console.ReadLine();
        }
    }
    class Camera
    {
        static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();
        static object _lock = new object();
        public Guid Id { get; set; }

        private Camera()
        {
            Id = Guid.NewGuid();
        }
        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_cameras.ContainsKey(brand))
                {
                    _cameras.Add(brand, new Camera());
                }
            }
            return _cameras[brand];
        }
    }
}
