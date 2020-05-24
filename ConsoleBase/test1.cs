
using System.Collections.Generic;

namespace ConsoleBase
{
    public class test1
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int? ExtId { get; set; }

        // указываем родительскую таблицу для доступа к ней
       // public Table_1 Table_1s { get; set; }
        //public virtual ICollection<Table_1> Table_1 { get; set; }
    }
}
