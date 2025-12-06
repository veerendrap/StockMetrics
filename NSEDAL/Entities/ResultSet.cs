using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEDAL.Entities
{
    public class ResultSet<T>
    {
        public ResultSet()
        {
            this.Rows = new List<T>();
        }

        public IList<T> Rows { get; set; }

        public int TotalRows { get; set; }

        public JsonResultSet<T> ToJsonResultSet()
        {
            return new JsonResultSet<T>
            {
                rows = this.Rows,
                total = TotalRows
            };
        }


    }
}
