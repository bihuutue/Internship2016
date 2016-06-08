using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Cat;
using Dog;

namespace CreateObjectFromText
{
    class COFT
    {
        static void Main(string[] args)
        {
            //Dog.Dog pup = new Dog.Dog();
            //Cat.Cat kit = new Cat.Cat();

            MagicallyCreateInstance("Dog");
            Console.ReadKey();
        }
        private static object MagicallyCreateInstance(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes()
                .First(t => t.Name == className);

            return Activator.CreateInstance(type);
        }
    }
}
