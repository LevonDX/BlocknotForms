using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotForms
{
    public class Record
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public static Record Parse(string s)
        {
            // s -> name-----phone

            Record record = new Record();

            int index = s.IndexOf("-");
            record.Name = s.Substring(0, index);

            int lastIndex = s.LastIndexOf("-");
            record.Phone = s.Substring(lastIndex + 1);

            return record;
        }

        public override string ToString()
        {
            return $"{Name} --- {Phone}";
        }
    }
}