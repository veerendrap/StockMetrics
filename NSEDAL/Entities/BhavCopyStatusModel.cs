using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSEDAL.Entities
{
    public class BhavCopyStatusModel
    {
        public string D { get; set; }
        public string SyncDate { get; set; }

        public string syncDateFormatted { get; set; }

        public string SyncFileName { get; set; }

        public string SyncURL { get; set; }

        public string StatusName { get; set; }
    }
}
