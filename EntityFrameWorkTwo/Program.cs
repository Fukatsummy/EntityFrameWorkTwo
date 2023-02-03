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
            AddFruit(new fandv(7, "name7", "fruits", "purpl", 456));
            MyTransaction();
            GetAllFruits();
            Console.ReadLine();
        }
        static void AddFruit(fandv item)
        {
            using (FruitsAndVagatableEntities2 fandvEntities = new FruitsAndVagatableEntities2()) 
            { 
                fandv exist = fandvEntities.fandv.Where((x)=>x.Id == item.Id /*&& x.Name == item.Name*/).FirstOrDefault();
                if(exist ==null)
                {
                    fandvEntities.fandv.Add(item);
                    fandvEntities.SaveChanges();
                }
            }
        }
        static void GetAllFruits()
        {
            using (FruitsAndVagatableEntities2 fandvEntities = new FruitsAndVagatableEntities2())
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
        static void MyTransaction()
        {
            using(FruitsAndVagatableEntities2 fandvEntities = new FruitsAndVagatableEntities2())
            {
                using (System.Data.Entity.DbContextTransaction tran = fandvEntities.Database.BeginTransaction())
                {
                    try
                    {
                        fandv fav = new fandv(8, "name8", "fruits", "pink", 769);
                        fandvEntities.fandv.Add(fav);
                        //fandvEntities.fandv.Remove(fav);
                        fandvEntities.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                }
            }
        }
    }
}
