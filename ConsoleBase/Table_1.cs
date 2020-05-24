using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBase
{
    public class Table_1
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Boss { get; set; }

        [Display(Name = "Тест даты")]
        [DataType(DataType.Date)]
        public DateTime Test { get; set; }

        // [Column(TypeName = "decimal(18, 2)")]
        public decimal fl { get; set; }

        // указываем подчиненную таблицу для доступа по выбранному id
       // public virtual ICollection<test1> test1 { get; set; }
       // public test1 test1s { get; set; }
    }
}
