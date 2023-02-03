using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AddFruit(new fandv(5, "name5", "fruit", "yeloww", 37));
            GetAllFruits();
            Console.ReadLine();
        }
        static void AddFruit(fandv item)
        {
            using (FruitsAndVagatableEntities1 fandvEntities = new FruitsAndVagatableEntities1()) 
            { 
                fandvEntities.fandv.Add(item);
                fandvEntities.SaveChanges();
            }
        }
        static void GetAllFruits()
        {
            using (FruitsAndVagatableEntities1 fandvEntities = new FruitsAndVagatableEntities1())
            {
                List<fandv> list = fandvEntities.fandv.ToList();
                foreach(fandv item in list)
                {
                    if(item.Type =="fruits")
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
