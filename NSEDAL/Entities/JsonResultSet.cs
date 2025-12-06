using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEDAL.Entities
{
    public class JsonResultSet<T>
    {
        public IList<T> rows { get; set; }

        public int total { get; set; }
    }
}
