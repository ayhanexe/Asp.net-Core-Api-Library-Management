using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class BookDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public double StarCount { get; set; }
    }
}
