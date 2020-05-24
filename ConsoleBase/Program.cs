
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleBase
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new MyDbContext1())
            {

                //// создаем 1 запись
                //var rec = new List<Table_1>
                //{ 
                //    new Table_1() {
                //    Name = "ddddd",
                //    Boss = 1,
                //    fl = 14,
                //    Test = DateTime.Now
                //    }
                //};

                //// добавляем нашу запись в базу
                //context.Table_1s.AddRange(rec);

                //// применяем изменения таблицы к самой базе, до этого это все в памяти
                //context.SaveChanges();

                //Console.WriteLine(rec);

                //Console.ReadLine();

                string a = "";
                //
                a = JsonConvert.SerializeObject(context.test1s);
                Console.WriteLine(a);

                //foreach (var i in context.test1s)
                //{
                //    a = JsonConvert.SerializeObject(i);
                //  //  a = JsonSerializer.Serialize(i);
                //    Console.WriteLine(a);
                //    //Console.WriteLine($"Name : {i.Name}");
                //}

                Console.ReadLine();
            }
        }
    }
}
