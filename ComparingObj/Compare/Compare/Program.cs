using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Obj> List1 = new List<Obj>();
            List<Obj> List2 = new List<Obj>();

            for (int i = 0; i < 3; i++)
            {
                Obj temp = new Obj();
                temp.age = 20 + i;
                temp.name = "Westmonland" + i.ToString();
                List1.Add(temp);
            }

            for (int i = 0; i < 3; i++)
            {
                Obj temp = new Obj();
                temp.age = 20 + i+3;
                temp.name = "Westmonland" + i.ToString();
                List2.Add(temp);
            }

            for (int i = 0; i < List1.Count; i++)
            {
                for (int j = 0; j < List2.Count; j++)
                {
                    if (List1[i].name == List2[j].name)
                    {
                        List1[i] = List2[j];
                    }
                }
            }
            for (int i = 0; i < List1.Count; i++)
            {
                Console.WriteLine(List1[i].age);
            }
        }
    }
    class Obj
    {
        public string name;
        public int age;
    }
}
